<script setup>
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <RouterView />
  </main>
  <footer class=" text-center">
    Made with <i class="mdi mdi-emoticon-devil text-orange"></i> by MayhemK
  </footer>
</template>

<style lang="scss">
main {
  background-color: #fef6f0;
  font-family: inter;
}
</style>
