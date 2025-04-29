namespace keepr.Services;

public class VaultKeepersService
{
  public VaultKeepersService(VaultKeepersRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultKeepersRepository _repository;
}