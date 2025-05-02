namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private ProfileService _profileService;
  private readonly Auth0Provider _auth0Provider;
  private VaultKeepersService _vaultKeepersService;

  public ProfilesController(ProfileService profileService, Auth0Provider auth0Provider, VaultKeepersService vaultKeepersService)
  {
    _profileService = profileService;
    _vaultKeepersService = vaultKeepersService;
    _auth0Provider = auth0Provider;
  }


  [HttpGet("{profilesId}")]
  async public Task<ActionResult<Profiles>> GetProfileById(string profilesId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profiles profiles = _profileService.GetProfileById(profilesId, userInfo);
      return Ok(profiles);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}