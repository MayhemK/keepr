<script setup>
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';

</script>

<template>
  <div id="app-container">
    <header class=" app-header order-2 order-md-1 sticky-top">
      <Navbar />
    </header>
    <main class="app-content order-1 order-md-2">
      <RouterView />
    </main>
  </div>
  <div>what

  </div>

  <!-- <header>
    <Navbar />
  </header>
  <main>
    <RouterView />
  </main>
  <footer class=" text-center">
    Made with <i class="mdi mdi-emoticon-devil text-orange"></i> by MayhemK
  </footer> -->

</template>

<style lang="scss">
#app-container {
  display: flex;
  flex-direction: column;
  min-height: 100dvh;
  background-color: #fef6f0;
  font-family: inter;
}

#app-header {
  position: relative;
  flex-shrink: 0;
  width: 100%;
  z-index: 1;
}

#app-content {
  flex-grow: 1;
}

@media (max-width: 768px) {
  .app-header {
    position: sticky;
    bottom: 0;
    width: 100%;
    z-index: 69;
  }
}
</style>
