import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Vault } from "@/models/Vault.js"

class VaultsService {
  async getAllVaults() {
    const res = await api.get('api/vaults')
    logger.log('GOT VAULTS', res.data)
    AppState.vaults = res.data.map(pojo => new Vault(pojo))
  }
}

export const vaultsService = new VaultsService()