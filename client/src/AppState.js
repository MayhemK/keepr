import { reactive } from 'vue'
import { Vault } from './models/Vault.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],
  /**@type {import('./models/Vault.js').Vault} */
  activeVault: null,
  /**@type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /**@type {import('./models/VaultKeeps.js').VaultKeep[]} */
  vkkeeps: [],
  /**@type {import('./models/Keep.js').Keep} */
  activeKeep: null,
  /**@type {import('./models/Account.js').Account} */
  activeProfile: null,
  /**@type {Vault[]} */
  myVaults: []
})

