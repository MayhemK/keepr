<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import KeepCard from '@/components/KeepCard.vue';
import KeepModal from '@/components/KeepModal.vue';
import { vaultsService } from '@/services/VaultsService.js';
import VaultCard from '@/components/VaultCard.vue';
import { AuthService } from '@/services/AuthService.js';

const account = computed(() => AppState.account)
const identity = computed(() => AppState.identity)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

onMounted(() => {
  getAllKeeps()
  getAllVaults()
})

async function getAllKeeps() {
  await keepsService.getAllKeeps()
}
async function getAllVaults() {
  await vaultsService.getAllVaults()
}
function logout() {
  AuthService.logout()
}
</script>

<template>
  <div class="about text-center">
    <div v-if="account">
      <img :src="account.coverImg" :alt="identity.nickname + ' profile cover image'">
      <img :src="account.picture" :alt="identity.nickname + ' account picture'">
      <div>... edit account</div>
      <div class="fs-3 marko-font">
        {{ account.name }}
      </div>
      <div>
        <span># Vaults | # Keeps</span>
      </div>
      <div>
        <div>Vaults</div>
        <div>
          <section class="container">
            <div class="row">
              <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
                <RouterLink :to="{ name: 'VaultPage', params: { vaultId: vault.id } }"
                  :title="`Go to ${vault.name} page`">
                  <div>
                    <VaultCard :vault="vault" />
                  </div>
                </RouterLink>
              </div>
            </div>
          </section>
        </div>
      </div>
      <div>
        <div>Keeps</div>
        <div>
          <section class="container pt-3">
            <div class="masonry-row">
              <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
                <div v-if="account.id == keep.creatorId">
                  <KeepCard :keep="keep" />
                </div>
              </div>
            </div>
          </section>


        </div>
      </div>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
  <KeepModal />
</template>

<style scoped lang="scss">
img {
  max-width: 100px;
}

.masonry-row {
  column-count: 4;
  column-gap: 15px;
  padding: 0 15px;

  @media (max-width: 768px) {
    column-count: 2;
  }
}

.masonry-item {
  display: inline-block;
  width: 100%;
  margin-bottom: 15px;
  break-inside: avoid;

}
</style>
