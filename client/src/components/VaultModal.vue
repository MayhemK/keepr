<script setup>
import { Vault } from '@/models/Vault.js';

defineProps({
  vault: { type: Vault, required: true }
})

const emit = defineEmits(['close']);

const closeModal = () => {
  emit('close');
};
</script>


<template>
  <p>yerp</p>
</template>


<style lang="scss" scoped></style>