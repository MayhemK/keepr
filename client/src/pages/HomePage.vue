<script setup>
import { AppState } from '@/AppState.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted, ref } from 'vue';
import KeepCard from '@/components/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import KeepModal from '@/components/KeepModal.vue';
import { logger } from '@/utils/Logger.js';

const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getAllKeeps()
})


async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}



</script>

<template>
  <section class="container">
    <div class="masonry-row">
      <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
        <KeepCard :keep="keep" />
      </div>
    </div>
  </section>


  <KeepModal />
</template>

<style scoped lang="scss">
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
