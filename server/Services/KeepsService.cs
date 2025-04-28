
namespace keepr.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }
  private readonly KeepsRepository _repository;
  private readonly VaultsService _vaultsService;

  internal Keep Create(Keep keepData, Account userInfo)
  {
    Vault vault = _vaultsService.GetVaultById(keepData.VaultId, userInfo);
    Keep keep = _repository.Create(keepData);
    return keep;
  }
}