<template>
    <div>
        <basic-profile-info />
        <change-password-form />
    </div>
</template>

<script lang="ts">
import BasicProfileInfo from "@/components/ProfileInfoComponent.vue";
import ChangePasswordForm from "@/components/ChangePasswordForm.vue";

export default {
    components: {
        BasicProfileInfo,
        ChangePasswordForm
    },
    setup() {
        
    }
}
</script>