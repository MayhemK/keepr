




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
    
    SELECT * FROM vaultKeep WHERE id = LAST_INSERT_ID();";

    VaultKeeps vaultKeeps = _db.Query<VaultKeeps>(sql, vaultKeeperData).SingleOrDefault();
    return vaultKeeps;
  }

  internal List<VKModel> GetVaultKeepsProfileByVaultId(int vaultId)
  {
    // string sql = @"
    // SELECT
    // vaultKeep.*,
    // accounts.*
    // FROM vaultKeep
    // INNER JOIN accounts ON accounts.id = vaultKeep.creator_id
    // WHERE vaultKeep.vault_id = @vaultId;";

    string sql = @"
    SELECT
    vaultKeep.*,
    keeps.*,
    accounts.*
    FROM vaultKeep
    INNER JOIN accounts ON accounts.id = vaultKeep.creator_id
    INNER JOIN keeps ON keeps.id = vaultKeep.keep_id
    WHERE vaultKeep.vault_id = @vaultId;";

    // string sql = "SELECT * FROM vaultKeep WHERE vault_id = @vaultId;";

    List<VKModel> vaultKeepsProfiles = _db.Query(sql, (VaultKeeps vaultkeeps, VKModel model, Profile account) =>
    {
      model.Creator = account;
      model.VaultKeepId = vaultkeeps.Id;
      return model;
    }, new { vaultId }).ToList();

    // List<VaultKeepsProfile> vaultKeepsProfiles = _db.Query<VaultKeepsProfile>(sql, new { vaultId }).ToList();
    return vaultKeepsProfiles;
  }

  internal void DeleteVaultKeeps(int vaultKeepsId)
  {
    string sql = "DELETE FROM vaultKeep WHERE id = @vaultKeepsId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { vaultKeepsId });
    // if (rowsAffected != 1)
    // {
    //   throw new Exception(rowsAffected + " Rows were deleted, Only one was intended");
    // }
  }

  internal VaultKeeps GetVaultKeepsById(int vaultKeepsId)
  {
    string sql = "SELECT * FROM vaultKeep WHERE id = @vaultKeepsId;";

    VaultKeeps vaultKeeps = _db.Query<VaultKeeps>(sql, new { vaultKeepsId }).SingleOrDefault();
    return vaultKeeps;
  }

  internal List<VaultKeepsProfile> GetVaultKeepsProfileByAccountId(object vaultId)
  {
    throw new NotImplementedException();
  }
}