<template>
    <div>
        Email<input type="text" v-model="email"/>
        <br>
        Password<input type="password" v-model="password"/>
        <button @click.prevent="handleLogin">
            Login
        </button>
        <br>
        <router-link to="/Register">Register</router-link>
        <router-link to="/ForgotPassword">Forgot Password?</router-link>
    </div>
</template>

<script lang="ts">
import { ref } from "vue";
import { Login } from '@/auth/authentication';
import router from '@/router';

export default {
    setup() {
        const email = ref('')
        const password = ref('')

        const handleLogin = async () => {
            var result = await Login(email.value, password.value)
            if(result === 200) {
                router.push({ path: '/' });
            }
        }

        return {
            email,
            password,
            handleLogin
        }
    }
}
</script>