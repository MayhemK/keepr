import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Vault } from "@/models/Vault.js"
import App from "@/App.vue"
import { Keep } from "@/models/Keep.js"
import { Pop } from "@/utils/Pop.js"
import { VaultKeep } from "@/models/VaultKeeps.js"

class VaultsService {
  async removeKeepFromVault(vaultKeepId) {
    try {
      const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
      logger.log((res.data));
      // AppState.vkkeeps = AppState.vkkeeps.filter(k => k.vaultKeepId !== vaultKeepId);
      
    }
    catch (error){
      Pop.error(error);
    }
  }
  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.activeVault = new Vault(res.data)
  }
  async getAllVaults() {
    const res = await api.get('api/vaults')
    // logger.log('GOT VAULTS', res.data)
    AppState.vaults = res.data.map(pojo => new Vault(pojo))
  }

  async getKeepsByVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log(res)
    AppState.vkkeeps = res.data.map(pojo => new VaultKeep(pojo))
  }

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    AppState.vaults.unshift(res.data);
    return res.data
  }
}


export const vaultsService = new VaultsService()