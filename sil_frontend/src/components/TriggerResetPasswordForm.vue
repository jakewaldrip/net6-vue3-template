<template>
    <div>
        <div v-if="emailSent">
            <p>An email has been sent to your account to reset your password.</p>
            <p>Please enter your security code to continue</p>
            <input type="text" v-model="securityCode"/>
            <button @click.prevent="handleSecurityCodeClicked()">Save</button>
        </div>
        <div v-else>
            <p>Enter your email to reset the password to your account</p>
            Email<input type="text" v-model="email"/>
            <button @click.prevent="handleTriggerButtonClicked()">Save</button>
        </div>
    </div>
</template>

<script lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";
import { TriggerPasswordReset, VerifyResetPassword} from "@/api/UserProfileApi";
import { PasswordVerifyData } from "@/types/user";

export default {
    setup() {
        const route = useRouter();
        const email = ref('');
        const securityCode = ref('')
        const emailSent = ref(false);

        const handleTriggerButtonClicked = async () => {
            const response = await TriggerPasswordReset(email.value);
            if(response.status === 200) {
                emailSent.value = true;
            }
        }

        const handleSecurityCodeClicked = async () => {
            const verifyData: PasswordVerifyData = {
                userEmail: email.value,
                token: securityCode.value
            }
            const response = await VerifyResetPassword(verifyData);
            if(response.status === 200) {
                route.push({ name: 'ResetPassword', params: { userEmail: email.value}})
            }
        }

        return {
            email,
            securityCode,
            emailSent,
            handleTriggerButtonClicked,
            handleSecurityCodeClicked
        }
    }
}
</script>