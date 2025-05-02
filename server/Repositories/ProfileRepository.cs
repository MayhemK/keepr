
namespace keepr.Repositories;

public class ProfileRepository
{
  private readonly IDbConnection _db;
  public ProfileRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profiles GetProfileById(string profilesId)
  {
    string sql = @"
    SELECT
    accounts.*
    FROM accounts
    WHERE id = @ProfilesId;";

    Profiles foundProfiles = _db.Query<Profiles>(sql, new { profilesId }).SingleOrDefault();
    return foundProfiles;
  }
}