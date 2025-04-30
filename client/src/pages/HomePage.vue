<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import VaultCard from '@/components/VaultCard.vue';
import { Vault } from '@/models/Vault.js';

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
      <div v-for="vault in vaults" :key="vault.id" class="col-md-3" type="button" data-bs-toggle="modal"
        data-bs-target="#vaultModal">
        <VaultCard :vault="vault" />
      </div>
    </div>
  </section>
  <section>
    <div class="modal fade" id="vaultModal" tabindex="-1" aria-labelledby="vaultModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="metal-font fs-4" id="vaultModalLabel">Vault Name</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            vault description
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
