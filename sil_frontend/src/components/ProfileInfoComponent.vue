<template>

    <div>
        Name <input :disabled="!profileEditActive" type="text" v-model="user.name">
        Email <input :disabled="!profileEditActive" type="text" v-model="user.email">
        Twitter Handle <input :disabled="!profileEditActive" type="text" v-model="user.twitterHandle">
        <button  @click.prevent="toggleEditFormClicked()">
            <span v-if="!profileEditActive">Edit</span>
            <span v-else>Cancel</span>
        </button>
        <button :disabled="!profileEditActive" @click.prevent="handleSaveButtonClicked()">Save</button>
    </div>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue';
import { User } from '@/types/user';
import { GetUser, RefreshUserCache } from '@/auth/authentication';
import { SaveUserProfile } from '@/api/UserProfileApi';

export default {
    setup() {
        const user = ref({} as User);
        const profileEditActive = ref(false);

        onMounted(async () => {
            const localUser = GetUser()
            // Refresh user cache with new edited user values
            const userData = await RefreshUserCache(localUser ? localUser.id : null);
            user.value = userData ?? {} as User;
        });

        const toggleEditFormClicked = () => {
            profileEditActive.value = !profileEditActive.value;
        }

        const handleSaveButtonClicked = async () => {
            profileEditActive.value = false;
            await SaveUserProfile(user.value);
        }

        return {
            user,
            handleSaveButtonClicked,
            toggleEditFormClicked,
            profileEditActive
        }
    }
}
</script>