

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

  internal List<Keep> GetAll()
  {
    string sql = @"
    SELECT
    keeps.*,
    accounts.*
    FROM keeps
    INNER JOIN accounts ON accounts.id = keeps.creator_id;";

    List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetById(int keepId)
  {
    string sql = @"
    SELECT
    keeps.*,
    accounts.*
    FROM keeps
    INNER JOIN accounts ON accounts.id = keeps.creator_id
    WHERE keeps.id = @id;";

    Keep foundKeep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { keepId }).SingleOrDefault();
    return foundKeep;
  }
}