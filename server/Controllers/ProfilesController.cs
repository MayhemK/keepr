namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private ProfileService _profileService;
  private readonly Auth0Provider _auth0Provider;
  private VaultKeepersService _vaultKeepersService;
  private KeepsService _keepsService;
  private VaultsService _vaultsService;

  public ProfilesController(ProfileService profileService, Auth0Provider auth0Provider, VaultKeepersService vaultKeepersService, KeepsService keepsService, VaultsService vaultsService)
  {
    _profileService = profileService;
    _vaultKeepersService = vaultKeepersService;
    _auth0Provider = auth0Provider;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }


  [HttpGet("{profilesId}")]
  async public Task<ActionResult<Profiles>> GetProfileById(string profilesId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profiles profiles = _profileService.GetProfileById(profilesId);
      return Ok(profiles);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
  {
    try
    {
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(profileId);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  async public Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(profileId, userInfo);
      return Ok(vaults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}