<script setup>
import { logger } from '@/utils/Logger.js';
import { ref, watch } from 'vue';

const props = defineProps({
  isVisible: {
    type: Boolean,
    default: false
  }
});

const emit = defineEmits(['close', 'createKeep']);

const title = ref('');
const imageUrl = ref('');
const description = ref('');

// Reset form when modal is opened
watch(() => props.isVisible, (newValue) => {
  if (newValue) {
    title.value = '';
    imageUrl.value = '';
    description.value = '';
  }
});

function closeModal() {
  emit('close');
}

function handleCreateKeep() {
  const newKeepData = {
    name: title.value,
    img: imageUrl.value,
    description: description.value

  };
  logger.log('Attempting to create keep with data:', newKeepData); // Log data for debugging
  emit('createKeep', newKeepData);
}

</script>

<template>
  <div v-if="isVisible" class="modal-overlay" @click.self="closeModal">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Add your keep</h5>
        <button type="button" class="close-button" @click="closeModal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <form @submit.prevent="handleCreateKeep">
          <div class="form-group">
            <label for="keep-title" class="form-label visually-hidden">Title</label>
            <input type="text" id="keep-title" class="form-control" v-model="title" placeholder="Title..." required>
          </div>
          <div class="form-group">
            <label for="keep-image" class="form-label visually-hidden">Image URL</label>
            <input type="url" id="keep-image" class="form-control" v-model="imageUrl" placeholder="Image URL..."
              required>
          </div>
          <div class="form-group">
            <label for="keep-description" class="form-label visually-hidden">Keep Description</label>
            <textarea id="keep-description" class="form-control description-textarea" v-model="description"
              placeholder="Keep Description..." rows="4"></textarea>
          </div>
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" @click="handleCreateKeep">Create</button>
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
}

.modal-body {
  flex-grow: 1;
  margin-bottom: 15px;

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
}

.modal-footer {
  border-top: 1px solid #eee;
  padding-top: 15px;
  display: flex;
  justify-content: flex-end;

  .btn-primary {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 10px 20px;
    border-radius: 4px;
    cursor: pointer;
    font-size: 1rem;

    &:hover {
      background-color: #0056b3;
    }
  }
}
</style>