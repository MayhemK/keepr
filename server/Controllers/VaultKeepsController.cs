using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(VaultKeepersService vaultKeepersService, Auth0Provider auth0Provider, VaultsService vaultsService)
  {
    _vaultKeepersService = vaultKeepersService;
    _auth0Provider = auth0Provider;
    _vaultsService = vaultsService;
  }
  private readonly VaultKeepersService _vaultKeepersService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultsService;
  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeeps>> CreateVK([FromBody] VaultKeeps vaultKeeperData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(vaultKeeperData.VaultId, userInfo);
      if (vault.CreatorId != userInfo.Id)
      {
        throw new Exception("Can't Add Keeps to a vault that isn't yours");
      }
      vaultKeeperData.CreatorId = userInfo.Id;
      VaultKeeps vaultKeeper = _vaultKeepersService.CreateVK(vaultKeeperData);
      return Ok(vaultKeeper);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vaultKeepsId}")]
  public async Task<ActionResult<string>> DeleteVaultKeeps(int vaultKeepsId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      _vaultKeepersService.DeleteVaultKeeps(vaultKeepsId, userInfo);
      return Ok("Keep removed from Vault!");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



}