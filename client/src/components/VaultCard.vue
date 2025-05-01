<script setup>
import { Vault } from '@/models/Vault.js';

defineProps({
  vault: { type: Vault, required: true }
})


</script>


<template>
  <div class="mb-4" type="button">
    <div class="img-cont">
      <img :src="vault.img" :alt="`A picture of the ${vault.name} vault`" class="vault-img rounded-3">
      <div class="marko-font overlap">{{ vault.name }}</div>
      <div v-if="vault.isPrivate == true" class="mdi mdi-lock overlap-2 text-light text-shadow fs-2"></div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.img-cont {
  position: relative;
  display: block;
  border-bottom-left-radius: 8px;
  border-bottom-right-radius: 8px;
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
  border-bottom-left-radius: 8px;
  border-bottom-right-radius: 8px;
  z-index: 1;
}

.vault-img {
  min-height: 60px;
  display: block;
  width: 100%;
  height: auto;
}

.overlap {
  position: absolute;
  bottom: 10px;
  left: 10px;
  color: #ffffff;

  padding: 5px 10px;
  font-size: 1.2rem;
  text-shadow: 1px 1px 3px black;
  z-index: 2;
}

.overlap-2 {
  position: absolute;
  bottom: 10px;
  right: 10px;
  z-index: 2;
}
</style>