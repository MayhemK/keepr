
namespace keepr.Services;

public class VaultKeepersService

{
  public VaultKeepersService(VaultKeepersRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }
  private readonly VaultKeepersRepository _repository;
  private readonly VaultsService _vaultsService;

  internal VaultKeeps CreateVK(VaultKeeps vaultKeeperData)
  {
    VaultKeeps vaultKeeps = _repository.CreateVK(vaultKeeperData);
    return vaultKeeps;
  }

  internal void DeleteVaultKeeps(int vaultKeepsId, Account userInfo)
  {
    VaultKeeps vaultKeeps = GetVaultKeepsById(vaultKeepsId);
    if (vaultKeeps.CreatorId != userInfo.Id)
    {
      throw new Exception("You can't delete another user's VaultKeep!");
    }
    _repository.DeleteVaultKeeps(vaultKeepsId);
  }

  private VaultKeeps GetVaultKeepsById(int vaultKeepsId)
  {
    VaultKeeps vaultKeeps = _repository.GetVaultKeepsById(vaultKeepsId);
    if (vaultKeeps == null)
    {
      throw new Exception("Invalid id: " + vaultKeepsId);
    }

    return vaultKeeps;
  }

  internal List<VKModel> GetVaultKeepsProfileByVaultId(int vaultId, Profile userId)
  {

    _vaultsService.GetVaultById(vaultId, userId);
    List<VKModel> vKModels = _repository.GetVaultKeepsProfileByVaultId(vaultId);
    return vKModels;
  }


}