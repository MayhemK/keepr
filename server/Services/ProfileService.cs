namespace keepr.Services;

public class ProfileService
{
  private readonly ProfileRepository _repository;
  public ProfileService(ProfileRepository repository)
  {
    _repository = repository;
  }

  internal Profiles GetProfileById(string profilesId, Profile userInfo)
  {
    Profiles profiles = _repository.GetProfileById(profilesId);
    return profiles;
  }

}