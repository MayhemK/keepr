
namespace keepr.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultsRepository _repository;
  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _repository.CreateVault(vaultData);
    return vault;
  }

  internal List<Vault> GetVaults()
  {
    List<Vault> vaults = _repository.GetVaults();
    return vaults;
  }
}