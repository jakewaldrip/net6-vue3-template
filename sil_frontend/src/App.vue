<template>
  <div>
    <navbar />
    <div id="app">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
  import Navbar from "@/components/Navbar.vue"

    export default {
      components: {
        Navbar
      }
    }
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
