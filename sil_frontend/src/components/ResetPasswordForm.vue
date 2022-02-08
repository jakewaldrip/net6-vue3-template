<template>
    <div>
        Password <input type="password" v-model="password">
        Confirm Password <input type="password" v-model="confirmPassword">
        <button @click.prevent="handleSaveButtonClicked()">Save</button>
    </div>
</template>

<script lang="ts">
import { ref } from "vue";
import { PasswordResetData } from "@/types/user";
import { SaveResetPassword } from "@/api/UserProfileApi";
import { useRouter } from "vue-router";

export default {
    props: {
        userEmail: {
            type: String,
            required: true
        }
    },
    setup(props) {
        const router = useRouter();
        const password = ref('');
        const confirmPassword = ref('');

        const handleSaveButtonClicked = async () => {
            const passwordData: PasswordResetData = {
                userEmail: props.userEmail,
                password: password.value
            }
            await SaveResetPassword(passwordData);
            router.push({ name: 'Login'})
        }

        return {
            password,
            confirmPassword,
            handleSaveButtonClicked
        }
    }
}
</script>