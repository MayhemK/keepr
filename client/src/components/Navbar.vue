<script setup>
import { AppState } from '@/AppState.js';
import Login from './Login.vue';
import { AuthService } from '@/services/AuthService.js';
import { computed } from 'vue';
import { Pop } from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';

const identity = computed(() => AppState.identity)
const account = computed(() => AppState.account)
const emit = defineEmits(['openCreateKeepModal', 'openCreateVaultModal']);
function login() {
  AuthService.loginWithRedirect()
}
function logout() {
  AuthService.logout()
}
function createNewVault() {
  try {
    logger.log('creat new vault')
  }
  catch (error) {
    Pop.error(error);
  }
}

function createNewKeep() {
  try {
    logger.log('create new keep')
    emit('openCreateKeepModal')
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <nav class="navbar marko-font bg-keep border-bottom border-gray">
    <div class="container gap-2">
      <div>
        <RouterLink :to="{ name: 'Home' }" class="d-flex align-items-center text-dark">
          <div>Home</div>
        </RouterLink>
        <div v-if="account" class="d-flex align-items-center gap-2">
          <button class="btn btn-outline-dark btn-sm" @click="createNewKeep">New Keep</button>
          <button class="btn btn-outline-dark btn-sm" @click="createNewVault">New Vault</button>
        </div>
      </div>

      <img class="navbar-brand" alt="logo" src="/src/assets/img/Keepr logo.png" height="65" />

      <div>
        <div v-if="account">
          <RouterLink :to="{ name: 'Account' }">
            <img :src="account.picture" alt="" height="40">
          </RouterLink>
          <span type="button" @click="logout()" class="mdi mdi-logout fs-4 ms-2 align-middle">
          </span>
        </div>
        <button class="btn selectable text-danger" @click="login" v-else>
          Login
        </button>

      </div>

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
