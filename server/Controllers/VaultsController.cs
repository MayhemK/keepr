using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(VaultsService vaultService, Auth0Provider auth0Provider)
  {
    _vaultsService = vaultService;
    _auth0Provider = auth0Provider;
  }

  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.CreateVault(vaultData);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Vault>> GetAllVaults()
  {
    try
    {
      List<Vault> vault = _vaultsService.GetVaults();
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}