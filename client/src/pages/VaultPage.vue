<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const vault = computed(() => AppState.activeVault)
const keeps = computed(() => AppState.vkkeeps)

onMounted(() => {
  getVaultById()
  getKeepsByVault()
})

async function getVaultById() {
  try {
    await vaultsService.getVaultById(route.params.vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getKeepsByVault() {
  try {
    await vaultsService.getKeepsByVault(route.params.vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div v-if="vault">
    <section class="container">
      <div class="row justify-content-center">
        <div class="col-6">
          <img :src="vault.img" alt="">
          <div class="fs-2 text-center marko-font">{{ vault.name }}</div>
        </div>
      </div>
    </section>
    <section class="container pt-3">
      <div class="masonry-row">
        <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
          <KeepCard :keep="keep" :hideCreator="true" />
        </div>
      </div>
    </section>


    <KeepModal />
  </div>
  <div v-else class="fs-1 text-center">Please Try Again</div>
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
  height: auto;
  display: block;
  margin: 0 auto;
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