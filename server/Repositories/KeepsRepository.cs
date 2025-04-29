namespace keepr.Repositories;

public class KeepsRepository
{
  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
  internal Keep Create(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps(name, description, img, creator_id)
    VALUES(@Name, @Description, @Img, @CreatorId);

    SELECT
    keeps.*,
    accounts.*
    FROM keeps
    INNER JOIN accounts on accounts.id = keeps.creator_id
    WHERE keeps.id = LAST_INSERT_ID();";

    Keep createdKeep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, keepData).SingleOrDefault();
    return createdKeep;
  }

}