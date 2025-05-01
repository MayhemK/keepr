using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider, VaultKeepersService vaultKeepersService)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
    _vaultKeepersService = vaultKeepersService;
  }

  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultKeepersService _vaultKeepersService;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.CreateVault(vaultData);
      return Ok(vault);
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

  [HttpGet("{vaultId}")]
  public ActionResult<Vault> GetVaultById(int vaultId)
  {
    try
    {
      Vault vault = _vaultsService.GetVaultById(vaultId);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{vaultId}")]
  public async Task<ActionResult<Vault>> Update(int vaultId, [FromBody] Vault vaultUpdateData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.Update(vaultId, userInfo, vaultUpdateData);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vaultId}")]
  public async Task<ActionResult<string>> Delete(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultsService.Delete(vaultId, userInfo);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{vaultId}/keeps")]
  public ActionResult<List<VKModel>> GetVaultKeepsProfileByVaultId(int vaultId)
  {
    try
    {
      List<VKModel> vKModels = _vaultKeepersService.GetVaultKeepsProfileByVaultId(vaultId);
      return Ok(vKModels);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}