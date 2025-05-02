namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
  private ProfileService _profileService;
  private VaultKeepersService _vaultKeepersService;

  public ProfileController(ProfileService profileService, VaultKeepersService vaultKeepersService)
  {
    _profileService = profileService;
    _vaultKeepersService = vaultKeepersService;
  }

}