import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { logger } from "@/utils/Logger.js"

class KeepsService {
setActiveKeep(value) {
  logger.log(value)
  AppState.activeKeep = value
}
clearKeep() {
  AppState.activeKeep = null
  logger.log('cleared active')

}
async getAllKeeps() {
  this.clearKeep()
  const res = await api.get('api/keeps')
  logger.log(res)
  AppState.keeps = res.data.map(pojo => new Keep(pojo))
}
async createKeepModal(newKeepData) {
  logger.log(newKeepData)
  const res = await api.post('api/keeps', newKeepData)
  AppState.keeps.unshift(res.data);
  return res.data
}
}
export const keepsService = new KeepsService()