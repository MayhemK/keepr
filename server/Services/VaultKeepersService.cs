
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
}