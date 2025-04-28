import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async getAllVaults() {
    const res = await api.get('api/vaults')
    logger.log('GOT VAULTS', res.data)
  }
}

export const vaultsService = new VaultsService()