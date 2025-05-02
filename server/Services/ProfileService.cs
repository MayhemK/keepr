namespace keepr.Services;

public class ProfileService
{
  private readonly ProfileRepository _repository;
  public ProfileService(ProfileRepository repository)
  {
    _repository = repository;
  }

  internal Profiles GetProfileById(string profilesId)
  {
    Profiles profiles = _repository.GetProfileById(profilesId);
    return profiles;
  }

}