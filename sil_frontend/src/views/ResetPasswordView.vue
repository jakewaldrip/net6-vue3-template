<template>
    <div>
        <reset-password-form :userEmail="userEmail"/>
    </div>
</template>

<script lang="ts">
import ResetPasswordForm from "@/components/ResetPasswordForm.vue";
import { useRoute } from "vue-router";
export default {
    components: {
        ResetPasswordForm
    },
    setup() {
        const route = useRoute();
        const userEmail = route.params['userEmail'];

        return {
            userEmail
        }
    }
}
</script>