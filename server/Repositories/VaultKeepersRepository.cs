
namespace keepr.Repositories;

public class VaultKeepersRepository
{
  public VaultKeepersRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal VaultKeeps CreateVK(VaultKeeps vaultKeeperData)
  {
    string sql = @"
    INSERT INTO
    vaultKeep(creator_id, vault_id, keep_id)
    VALUES (@CreatorId, @VaultId, @KeepId);
    
    SELECT * FROM vaultKeeps WHERE id = LAST_INSERT_ID();";

    VaultKeeps vaultKeeps = _db.Query<VaultKeeps>(sql, vaultKeeperData).SingleOrDefault();
    return vaultKeeps;
  }
}