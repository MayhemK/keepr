<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, ref } from 'vue';


const editableAccountData = ref({
  name: '',
  coverImg: '',
  picture: '',
})

onMounted(() => {
  const account = AppState.account
  editableAccountData.value = {
    name: account.name,
    coverImg: account.coverImg,
    picture: account.picture,
  }
})

async function updateAccount() {
  try {
    await accountService.updateAccount(editableAccountData.value)
    Pop.success('Account updated successfully!');
  }
  catch (error) {
    Pop.error('Failed to update account: ' + error.message);
  }
}

</script>

<template>
  <div class="d-flex justify-content-between">
    <h3>Edit Account Details</h3>
    <form @submit.prevent="updateAccount()">
      <div>
        <label for="accountName">Account Name</label>
        <input v-model="editableAccountData.name" type="text" name="name" id="accountName" required maxlength="60">
      </div>
      <div>
        <label for="accountPicture">Account Picture URL</label>
        <input v-model="editableAccountData.picture" type="url" id="accountPicture" name="picture" maxlength="500">
      </div>
      <div>
        <label for="accountCoverImg">Account Cover Image URL</label>
        <input v-model="editableAccountData.coverImg" type="url" name="coverImg" id="accountCoverImg" maxlength="500">
      </div>
      <div class="text-end">
        <button class="btn btn-green" type="submit">submit</button>
      </div>
    </form>
  </div>
</template>

<style lang="scss" scoped>
.btn-green {
  background-color: #f9f6fa;
  color: black;
}

form div {
  margin-bottom: 1rem;
}

form label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
}

form input[type="text"],
form input[type="url"] {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 4px;
}
</style>
