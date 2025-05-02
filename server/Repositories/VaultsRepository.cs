namespace keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;
  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }
  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"
    INSERT INTO
    vaults(name, description, img, is_private, creator_id)
    VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);
    
    SELECT
    vaults.*,
    accounts.*
    FROM vaults
    INNER JOIN accounts ON accounts.id = vaults.creator_id
    WHERE vaults.id = LAST_INSERT_ID();";

    Vault createdVault = _db.Query(sql, (Vault vault, Profile account) =>
    {
      vault.Creator = account;
      return vault;
    }, vaultData).SingleOrDefault();
    return createdVault;
  }


  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
    SELECT
    vaults.*,
    accounts.*
    FROM vaults
    INNER JOIN accounts ON accounts.id = vaults.creator_id
    WHERE vaults.id = @vaultId;";

    Vault foundVault = _db.Query(sql, (Vault vault, Profile account) =>
    {
      vault.Creator = account;
      return vault;
    }, new { vaultId }).SingleOrDefault();
    return foundVault;
  }

  internal List<Vault> GetVaults()
  {
    string sql = @"
    SELECT 
    vaults.*,
    accounts.*
    From vaults
    INNER JOIN accounts ON accounts.id = vaults.creator_id;";

    List<Vault> vaults = _db.Query(sql, (Vault vault, Profile account) =>
    {
      vault.Creator = account;
      return vault;
    }).ToList();
    return vaults;
  }

  internal void Update(Vault vaultUpdateData)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    is_private = @IsPrivate
    WHERE id = @Id LIMIT 1;";
    int rowsAffected = _db.Execute(sql, vaultUpdateData);
    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " Rows were updated, Only one was intended");
    }
  }

  public void Delete(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { vaultId });
    // if (rowsAffected != 1)
    // {
    //   throw new Exception(rowsAffected + " Rows were deleted, Only one was intended");
    // }
  }
}