import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { Account } from "@/models/Account.js"
import { logger } from "@/utils/Logger.js"

class ProfileService {

  async getProfileById(profileId) {
    const res = await api.get(`api/profiles/${profileId}`)
    AppState.activeProfile = new Account(res.data)
    logger.log('profile by ID' , res.data)
  }
  
}

export const profileService = new ProfileService()