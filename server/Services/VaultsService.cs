using Microsoft.AspNetCore.Http.HttpResults;

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

  internal Vault GetVaultById(int vaultId)
  {
    Vault vault = _repository.GetVaultById(vaultId);

    if (vault == null)
    {
      throw new Exception("No Vault Found With this Id");
    }
    return vault;
  }

  internal Vault GetVaultById(int vaultId, Profile userInfo)
  {
    Vault vault = _repository.GetVaultById(vaultId);


    if (vault.IsPrivate == true && vault.CreatorId != userInfo?.Id)
    {
      throw new Exception("Invalid Id");
    }
    return vault;
  }

  internal Vault Update(int vaultId, Profile userInfo, Vault vaultUpdateData)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("You can not update another user's Vault!");
    }

    vault.Name = vaultUpdateData.Name ?? vault.Name;
    vault.Description = vaultUpdateData.Description ?? vault.Description;
    vault.IsPrivate = vaultUpdateData.IsPrivate ?? vault.IsPrivate;

    _repository.Update(vault);
    return vault;
  }

  internal string Delete(int vaultId, Profile userInfo)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception($"You can't delete another user's Vault!");
    }
    _repository.Delete(vaultId);
    return vault.Name + " had been deleted!";
  }


}