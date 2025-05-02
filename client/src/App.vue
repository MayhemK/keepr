<script setup>
import { ref } from 'vue';
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';
import CreateKeepModal from './components/CreateKeepModal.vue';
import { Pop } from './utils/Pop.js';
import { keepsService } from './services/KeepsService.js';
import { vaultsService } from './services/VaultsService.js';
import CreateVaultModal from './components/CreateVaultModal.vue';
const showCreateKeepModal = ref(false);
const showCreateVaultModal = ref(false);

function openCreateKeepModal() {
  showCreateKeepModal.value = true;
}
function closeCreateKeepModal() {
  showCreateKeepModal.value = false;
}
function openCreateVaultModal() {
  showCreateVaultModal.value = true;
}
function closeCreateVaultModal() {
  showCreateVaultModal.value = false;
}
async function handleCreateKeep(newKeepData) {
  try {
    const createdKeep = await keepsService.createKeepModal(newKeepData)
    Pop.success('keep created successfully!')
  }
  catch (error) {
    Pop.error(error);
  }
  closeCreateKeepModal();
}

async function handleCreateVault(newVaultData) {
  try {
    const createdVault = await vaultsService.createVault(newVaultData)
    Pop.success('Vault created successfully!')
    closeCreateVaultModal()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <div id="app-container">
    <header class=" app-header order-2 order-md-1 sticky-top">
      <Navbar @open-create-keep-modal="openCreateKeepModal" @open-create-vault-modal="openCreateVaultModal" />
    </header>
    <main class="app-content order-1 order-md-2">
      <RouterView />
    </main>
  </div>
  <CreateKeepModal :isVisible="showCreateKeepModal" @close="closeCreateKeepModal" @createKeep="handleCreateKeep" />
  <CreateVaultModal :isVisible="showCreateVaultModal" @close="closeCreateVaultModal" @createVault="handleCreateVault" />
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
