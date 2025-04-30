<script setup>
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)

function clearKeep() {
  keepsService.clearKeep()
}
</script>


<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true"
    data-bs-backdrop="static" data-bs-keyboard="false">
    <div class="modal-dialog">
      <div v-if="keep" class="modal-content">
        <section class="container">
          <div class="row">
            <div class="col-md-6">
              hi
            </div>
            <div class="col-md-6">
              hi
            </div>
          </div>
        </section>
        <div class="modal-header mt-2">
          <h1 class="metal-font fs-4" id="keepModalLabel">
            {{ keep.name }}
          </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          {{ keep.description }}
        </div>
        <div class="modal-footer">
          <div>
            {{ keep.creator.name }}
            <button @click="clearKeep()" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
      <div v-else>
        NOPE
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>