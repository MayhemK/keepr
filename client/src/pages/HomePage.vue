<script setup>
import Example from '@/components/Example.vue';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';

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
  <Example />
</template>

<style scoped lang="scss"></style>
