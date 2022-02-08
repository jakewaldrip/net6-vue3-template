<template>
    <div class="post">
        <p>Cool post we made it</p>
        <input type="text" v-model="nameRef" />
        <button @click.prevent="getName()">Update Name From Backend</button>
    </div>
</template>

<script lang="ts">
    import { HelloWorldGetName } from "@/api/HelloWorldApi";
    import { ref } from 'vue'

    export default {
        setup() {
            const nameRef = ref('old name')

            const getName = async () => {
                try {
                    const result = await HelloWorldGetName();
                    nameRef.value = result.name;
                }
                catch (e) {
                    console.error(e);
                }
            }

            return {
                nameRef,
                getName
            }
        }
    }
</script>