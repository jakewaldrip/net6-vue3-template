<template>
    <div>
        <p>Logout</p>
    </div>
</template>

<script lang="ts">
import { onMounted } from "vue";
import { Logout } from "@/auth/authentication"
import { Sleep } from "@/common";
export default {
    setup() {
        onMounted(async () => {
            await Sleep(2000);
            Logout();
        })
    }
}
</script>