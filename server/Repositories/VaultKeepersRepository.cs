namespace keepr.Repositories;

public class VaultKeepersRepository
{
  public VaultKeepersRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
}