<script setup>
import { logger } from '@/utils/Logger.js';
import { ref, watch } from 'vue';

const props = defineProps({
  isVisible: {
    type: Boolean,
    default: false
  }
});

const emit = defineEmits(['close', 'createVault']);

const title = ref('');
const description = ref('');
const img = ref('');
const isPrivate = ref(false);

watch(() => props.isVisible, (newValue) => {
  if (newValue) {
    title.value = '';
    description.value = '';
    img.value = '';
    isPrivate.value = false;
  }
});

function closeModal() {
  emit('close');
}

function handleCreateVault() {
  const newVaultData = {
    Name: title.value,
    Description: description.value,
    Img: img.value,
    IsPrivate: isPrivate.value
  };
  logger.log('Attempting to create vault with data:', newVaultData);
  emit('createVault', newVaultData);
}
</script>

<template>
  <div v-if="isVisible" class="modal-overlay" @click.self="closeModal">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Add your vault</h5>
        <button type="button" class="close-button" @click="closeModal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <form @submit.prevent="handleCreateVault">
          <div class="form-group">
            <label for="vault-title" class="form-label visually-hidden">Title</label>
            <input type="text" id="vault-title" class="form-control" v-model="title" placeholder="Title..." required>
          </div>
          <div class="form-group">
            <label for="vault-description" class="form-label visually-hidden">Description</label>
            <textarea id="vault-description" class="form-control description-textarea" v-model="description"
              placeholder="Description..." rows="3"></textarea>
          </div>
          <div class="form-group">
            <label for="vault-img" class="form-label visually-hidden">Image URL</label>
            <input type="url" id="vault-img" class="form-control" v-model="img" placeholder="Image URL...">
          </div>
          <div class="d-flex justify-content-end align-items-center mt-3">
            <small class="text-muted me-2">Private Vaults can only be seen by you</small>
            <div class="form-check">
              <input type="checkbox" class="form-check-input" id="vault-private" v-model="isPrivate">
              <label class="form-check-label" for="vault-private">Make Vault Private?</label>
            </div>
          </div>
        </form>
      </div>
      <div class="modal-footer justify-content-end">
        <button type="button" class="btn btn-primary" @click="handleCreateVault">Create Vault</button>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1050;
}

.modal-content {
  background: white;
  padding: 20px;
  border-radius: 8px;
  width: 90%;
  max-width: 500px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
}

.modal-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1px solid #eee;
  padding-bottom: 10px;
  margin-bottom: 15px;
}

.modal-title {
  margin: 0;
  font-size: 1.5rem;
  font-weight: bold;
}

.close-button {
  background: none;
  border: none;
  font-size: 1.5rem;
  cursor: pointer;
  padding: 0;
}

.modal-body {
  flex-grow: 1;
  margin-bottom: 15px;
}

.form-group {
  margin-bottom: 15px;
}

.form-control {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  font-size: 1rem;
}

.description-textarea {
  resize: vertical;
}

.visually-hidden {
  position: absolute;
  width: 1px;
  height: 1px;
  margin: -1px;
  padding: 0;
  overflow: hidden;
  clip: rect(0, 0, 0, 0);
  border: 0;
}

.form-check {
  margin-top: 10px;
}

small.text-muted {
  font-size: 0.8rem;
}

.modal-footer {
  border-top: 1px solid #eee;
  padding-top: 15px;
  display: flex;
  justify-content: flex-end;
}

.btn-primary {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
}

.btn-primary:hover {
  background-color: #0056b3;
}
</style>