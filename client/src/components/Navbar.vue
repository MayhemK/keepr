<script setup>
import Login from './Login.vue';

</script>

<template>
  <nav class="navbar marko-font bg-keep border-bottom border-gray">
    <div class="container gap-2">
      <div>
        <RouterLink :to="{ name: 'Home' }" class="d-flex align-items-center text-dark">
          <div>Home</div>
        </RouterLink>
        <div>Create 🔻</div>
      </div>

      <img class="navbar-brand" alt="logo" src="/src/assets/img/Keepr logo.png" height="65" />

      <Login />

    </div>
  </nav>
</template>

<style lang="scss" scoped>
a {
  text-decoration: none;
}

.bg-keep {
  background-color: #fef6f0;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
