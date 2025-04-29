


namespace keepr.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }
  private readonly KeepsRepository _repository;

  internal Keep Create(Keep keepData)
  {
    Keep keep = _repository.Create(keepData);
    return keep;
  }

  internal List<Keep> GetAll()
  {
    List<Keep> keeps = _repository.GetAll();
    return keeps;
  }

  internal Keep GetById(int keepId)
  {
    Keep keep = _repository.GetById(keepId);

    if (keep == null)
    {
      throw new Exception("Invalid Keep ID");
    }
    return keep;
  }

  internal Keep Update(int keepId, Profile userInfo, Keep keepUpdateData)
  {
    Keep keep = GetById(keepId);
    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("You are not allowed to Update another user's Keep!");
    }

    keep.Name = keepUpdateData.Name ?? keep.Name;
    keep.Description = keepUpdateData.Description ?? keep.Description;
    keep.Img = keepUpdateData.Img ?? keep.Img;

    _repository.Update(keep);
    return keep;
  }

  internal string Delete(int keepId, Profile userInfo)
  {
    Keep keep = GetById(keepId);
    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("You are not allowed to Delete another user's Keep!");
    }
    _repository.Delete(keepId);
    return keep.Name + " had been deleted!";
  }
}