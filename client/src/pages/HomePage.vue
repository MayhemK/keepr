<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import VaultCard from '@/components/VaultCard.vue';

const vaults = computed(() => AppState.vaults)

onMounted(() => {
  getAllVaults()
})

async function getAllVaults() {
  try {
    await vaultsService.getAllVaults()
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <section class="container">
    <div class="row">
      <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
        <VaultCard :vault="vault" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">

</style>
