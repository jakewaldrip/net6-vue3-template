<template>
    <div>
        Email<input type="text" v-model="email"/>
        <br>
        Name<input type="text" v-model="name"/>
        <br>
        Twitter Handle<input type="text" v-model="twitterHandle"/>
        <br>
        Password<input type="password" v-model="password"/>
        <br>
        Confirm Password<input type="password" v-model="confirmPassword"/>
        <br>
        <button @click.prevent="handleRegister">
            Register
        </button>
    </div>
</template>

<script lang="ts">
import { ref,  } from "vue";
import { Register } from '@/auth/authentication';

export default {
    emits: ['registered'],
    setup(props, context) {
        const email = ref('');
        const name = ref('');
        const twitterHandle = ref('');
        const password = ref('')
        const confirmPassword = ref('');

        const handleRegister = async () => {
            var result = await Register(
                email.value, 
                name.value, 
                twitterHandle.value, 
                password.value
            );

            if(result === 200) {
                context.emit("registered");
            }
        }

        return {
            email,
            name,
            twitterHandle,
            password,
            confirmPassword,
            handleRegister
        }
    }
}
</script>