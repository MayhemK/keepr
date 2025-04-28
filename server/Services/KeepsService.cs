namespace keepr.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository repository, KeepsService keepsService)
  {
    _repository = repository;
    _keepsService = keepsService;
  }
  private readonly KeepsRepository _repository;
  private readonly KeepsService _keepsService;


}