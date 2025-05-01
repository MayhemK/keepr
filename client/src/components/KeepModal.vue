<script setup>
import { AppState } from '@/AppState.js';
import { router } from '@/router.js';
import { Modal } from 'bootstrap';
// import { keepsService } from '@/services/KeepsService.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)

function hideModal() {
  const modalElement = document.getElementById('keepModal');
  if (modalElement) {
    const modalInstance = Modal.getInstance(modalElement);
    if (modalInstance) {
      modalInstance.hide();
    }
    else {
      Modal.getOrCreateInstance('#keepModal').hide()
    }
  }
}

function hideAndNavigate() {
  hideModal();
  router.push({ name: 'Profile', params: { profileId: keep.value.creatorId } })
}

</script>


<template>
  <div class="modal fade inter-font" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-centered modal-fullscreen-md-down">
      <div v-if="keep" class="modal-content">
        <section class="container">
          <div class="row">
            <div class="col-md-6" id="image">
              <img :src="keep.img" :alt="keep.name + 'image'">
            </div>
            <div class="col-md-6" id="info">
              <button type="button" class="btn-close text-end d-block d-md-none exit-x" data-bs-dismiss="modal"
                aria-label="Close"></button>
              <div class="text-center mt-4">
                <span class="mdi mdi-eye">{{ keep.views }}</span>
                <span class="mdi mdi-key">{{ keep.kept }}</span>
              </div>
              <div class="text-center keep-title marko-font fs-3 mt-3">
                {{ keep.name }}
              </div>
              <div class="text-center mt-3">
                {{ keep.description }}
              </div>
              <div class="text-end footer mb-3 mt-4">
                <div>SAVE</div>
                <div>
                  <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creatorId } }"
                    @click.prevent="hideAndNavigate()">
                    <img class="prof-img" :src="keep.creator.picture" alt="">
                    {{ keep.creator.name }}
                  </RouterLink>
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>
      <div v-else>
        Please Reload Page
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  width: calc(100% + 1px);
  height: 100%;
  object-fit: cover;
  object-position: end;
  // display: block;
}

.modal-content {
  animation-name: zoom;
  animation-duration: 0.6s;
}

@keyframes zoom {
  from {
    transform: scale(0.1);
  }

  to {
    transform: scale(1);
  }
}

.exit-x {
  position: absolute;
  top: 10px;
  right: 10px;
  background-color: white;
}

.prof-img {
  max-width: 32px;

}

#info {
  display: grid;
  justify-content: space-around;
  // align-content: space-around;
  object-fit: cover;
}

#image {
  padding: 0px;
  display: flex;
  overflow: hidden;
  border-top-left-radius: 0rem;
  border-bottom-left-radius: 0rem;
}

@media (min-width: 768px) {
  #image {
    border-top-left-radius: 0.5rem;
    border-bottom-left-radius: 0.5rem;
  }
}

.footer {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: end;
}

.keep-title {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: end;
}

#keepModal {
  background-color: rgba(192, 206, 209, 0.5);
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
}
</style>