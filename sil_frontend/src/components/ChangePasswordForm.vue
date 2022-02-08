<template>
    <div>
        Password <input :disabled="!changePasswordEditActive" type="password" v-model="password">
        Confirm Password <input :disabled="!changePasswordEditActive" type="password" v-model="confirmPassword">
        <button  @click.prevent="toggleEditFormClicked()">
            <span v-if="!changePasswordEditActive">Edit</span>
            <span v-else>Cancel</span>
        </button>
        <button :disabled="!changePasswordEditActive" @click.prevent="handleSaveButtonClicked()">Save</button>
    </div>
</template>

<script lang="ts">
import { ref } from 'vue';
import { SaveChangedPassword } from '@/api/UserProfileApi';
import { PasswordChangeData } from '@/types/user';
import { GetUser } from '@/auth/authentication';

export default {
    setup() {
        const user = GetUser();
        const password = ref('');
        const confirmPassword = ref('');
        const changePasswordEditActive = ref(false);

        const toggleEditFormClicked = () => {
            changePasswordEditActive.value = !changePasswordEditActive.value;
        }

        const handleSaveButtonClicked = async () => {
            if(user == null) {
                return;
            }

            const passwordData: PasswordChangeData = {
                "userId": user.id,
                "password": password.value, 
            };
            changePasswordEditActive.value = false;
            await SaveChangedPassword(passwordData);
        }

        return {
            handleSaveButtonClicked,
            toggleEditFormClicked,
            changePasswordEditActive,
            password,
            confirmPassword
        }
    }
}
</script>