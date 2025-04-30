<script setup>
import { Vault } from '@/models/Vault.js';

defineProps({
  vault: { type: Vault, required: true }
})
</script>


<template>

  <div class="cards">
    <div class="img-cont">
      <img :src="vault.img" :alt="`A picture of the ${vault.name} vault`" class="vault-img rounded-3">
      <span class="metal-font overlap">{{ vault.name }}</span>
    </div>
  </div>
  <!-- <div>
    <div class="text-center">
      <p class="card-body border rounded-4">{{ vault.description }}</p>
    </div>
  </div> -->
</template>


<style lang="scss" scoped>
.vault-img {
  // display: block;
  width: 100%;
  height: auto;
}

.img-cont {
  position: relative;
  display: inline-block;
  overflow: hidden;
}

.img-cont::after {
  content: '';
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100px;
  background: linear-gradient(to top, rgba(0, 0, 0, 0.8) 0%, rgba(0, 0, 0, 0) 100%);
  pointer-events: none;
  z-index: 1;
}

.card-body {
  padding: 15px;
}

.overlap {
  position: absolute;
  bottom: 10px;
  left: 10px;
  color: orange;

  padding: 5px 10px;
  font-size: 1.2rem;
  text-shadow: 1px 1px 3px black;
  z-index: 2;
}
</style>