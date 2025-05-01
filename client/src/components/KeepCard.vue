<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';


const props = defineProps({
  keep: { type: Keep, required: true }
})

function setActiveKeep() {
  keepsService.setActiveKeep(props.keep)
}
</script>


<template>

  <div class="keep-card" type="button" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setActiveKeep()">
    <div class="img-cont">
      <img :src="keep.img" :alt="`A picture of the ${keep.name} keep`" class="keep-img rounded-3">
      <div class="metal-font overlap">{{ keep.name }}</div>
      <img :src="keep.creator.picture" class="prof-img overlap-2 rounded-5 ">
    </div>

  </div>
</template>


<style lang="scss" scoped>
.keep-img {
  min-height: 80px;
  display: block;
  width: 100%;
  height: auto;
}

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

.overlap-2 {
  position: absolute;
  bottom: 10px;
  right: 10px;
  z-index: 2;
}

.prof-img {
  max-height: 3rem;
  border: 2px black;

}
</style>