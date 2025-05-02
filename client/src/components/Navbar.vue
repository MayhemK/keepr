<script setup>
import { AppState } from '@/AppState.js';
import Login from './Login.vue';
import { AuthService } from '@/services/AuthService.js';
import { computed } from 'vue';

const identity = computed(() => AppState.identity)
const account = computed(() => AppState.account)

function login() {
  AuthService.loginWithRedirect()
}
function logout() {
  AuthService.logout()
}

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
      <div>
        <RouterLink :to="{ name: 'Account' }">
          <img :src="account.picture" alt="">
        </RouterLink>
      </div>
      <div>
        <span class="navbar-text">
          <button class="btn selectable text-warning" @click="login" v-if="!identity">
            Login
          </button>
          <div v-else>
            <div class="dropdown">
              <div role="button" class="selectable no-select" data-bs-toggle="dropdown" aria-expanded="false"
                title="open account menu">
                <div v-if="account?.picture || identity?.picture">
                  <img :src="account?.picture || identity?.picture" alt="account photo" height="40" class="user-img" />
                </div>
              </div>
              <div class="dropdown-menu dropdown-menu-sm-end dropdown-menu-start p-0" role="menu" title="account menu">
                <div class="list-group">
                  <RouterLink :to="{ name: 'Account' }">
                    <div class="list-group-item dropdown-items list-group-item-action">
                      Manage Account
                    </div>
                  </RouterLink>
                  <div class="list-group-item dropdown-item list-group-item-action text-danger selectable"
                    @click="logout">
                    <i class="mdi mdi-logout"></i>
                    logout
                  </div>
                </div>
              </div>
            </div>
          </div>
        </span>
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
