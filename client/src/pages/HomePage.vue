<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

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
  <p>HI</p>
  <section class="container">
    <div class="row">
      <div class="col-3">
        <div class="card">
          <p>IMAGE</p>
          <div class="card-body">
            <p>Inner text</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
