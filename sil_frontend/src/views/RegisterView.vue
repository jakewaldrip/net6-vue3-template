<template>
    <div v-if="!registered">
        <div>
            <register-form @registered="handleUserRegistered"/>
        </div>
    </div>
    <div v-else>
        <p>You are registered!</p>
    </div>
</template>

<script lang="ts">
import RegisterForm from '@/components/RegisterForm.vue';
import { ref } from 'vue';

export default {
    components: {
        RegisterForm
    },
    setup() {
        const registered = ref(false);

        const handleUserRegistered = () => {
            registered.value = true;
        }

        return {
            registered,
            handleUserRegistered
        }
    }
}
</script>