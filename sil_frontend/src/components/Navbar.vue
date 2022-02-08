<template>
    <div>
        <router-link to="/"> Home </router-link>
        <router-link to="/Test"> HelloWorldTest </router-link>
        <router-link v-show="authenticated" to="/Profile"> Profile </router-link>
        <router-link 
            to="/Login"
            v-if="!authenticated"
        >
            Login
        </router-link>
        <router-link 
            v-else 
            to="/Logout"
        >
             Logout 
        </router-link>
        <p v-show="authenticated"> Welcome, {{ name }}</p>
    </div>
</template>

<script lang="ts">
    import { ref, watch } from "vue"
    import { IsAuthenticated, GetUser } from '@/auth/authentication'
    import { useRoute } from "vue-router";
    
    export default {
        setup() {
            const authenticated = ref(IsAuthenticated());
            const name = ref('');
            const router = useRoute();

            watch(router, () => {
                authenticated.value = IsAuthenticated();
                const user = GetUser();
                name.value = user ? user.name : '';
            });

            return {
                authenticated,
                name
            }
        }
    }
</script>

<style scoped>
 p {
     padding-left: 10px;
     padding-right: 10px;
 }
</style>