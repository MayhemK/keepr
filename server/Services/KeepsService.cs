
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
}