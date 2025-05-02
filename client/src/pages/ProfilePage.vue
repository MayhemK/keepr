<script setup>
import { Pop } from '@/utils/Pop.js';
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { profileService } from '@/services/ProfileService.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import KeepModal from '@/components/KeepModal.vue';

const route = useRoute()
onMounted(() => {
  getProfileById()
})

function hideModal() {
  Modal.getOrCreateInstance('#keepModal').hide()
}

async function getProfileById() {
  try {
    const profileId = route.params.profileId
    await profileService.getProfileById(profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div>profile page</div>
  <!-- 
  <img :src="account.coverImg" :alt="identity.nickname + ' profile cover image'">
  <img :src="account.picture" :alt="identity.nickname + ' account picture'">
  <div>... edit account</div>
  <div>
    {{ account.name }}
  </div>
  <div>
    <span># Vaults | # Keeps</span>
  </div>
  <div>
    <div>Vaults</div>
    <div>
      <section class="container">
        <div class="row">
          <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
            <div v-if="account.id == vault.creatorId">
              <VaultCard :vault="vault" />
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
  <div>
    <div>Keeps</div>
    <div>
      <section class="container pt-3">
        <div class="masonry-row">
          <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
            <div v-if="account.id == keep.creatorId">
              <KeepCard :keep="keep" />
            </div>
          </div>
        </div>
      </section>


    </div>
  </div> -->
  <KeepModal />
</template>


<style lang="scss" scoped>
img {
  max-width: 100px;
}

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