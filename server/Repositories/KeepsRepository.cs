

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

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
    WHERE keeps.id = @keepId;";

    Keep foundKeep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { keepId }).SingleOrDefault();
    return foundKeep;
  }

  internal void Update(Keep keepUpdateData)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    img = @Img
    WHERE id = @Id LIMIT 1;";
    int rowsAffected = _db.Execute(sql, keepUpdateData);
    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " Rows were updated, Only one was intended");
    }
  }

  internal void Delete(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { keepId });
    // if (rowsAffected != 1)
    // {
    //   throw new Exception(rowsAffected + " Rows were deleted, Only one was intended");
    // }
  }

  internal void IncreaseViews(Keep keep)
  {
    string sql = @"
    UPDATE keeps
    SET views = @Views
    WHERE id = @Id LIMIT 1;";
    int rowsAffected = _db.Execute(sql, keep);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected and that is bad");
    }
  }
}