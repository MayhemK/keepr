



namespace keepr.Services;

public class VaultKeepersService
{
  public VaultKeepersService(VaultKeepersRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultKeepersRepository _repository;

  internal VaultKeeps CreateVK(VaultKeeps vaultKeeperData)
  {
    VaultKeeps vaultKeeps = _repository.CreateVK(vaultKeeperData);
    return vaultKeeps;
  }

  internal List<VaultKeepsProfile> GetVaultKeepsProfileByVaultId(int vaultId)
  {
    List<VaultKeepsProfile> vaultKeepsProfiles = _repository.GetVaultKeepsProfileByVaultId(vaultId);
    return vaultKeepsProfiles;
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
}