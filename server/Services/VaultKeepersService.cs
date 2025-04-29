

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
}