


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
      throw new Exception("Invalid ID");
    }
    return keep;
  }
}