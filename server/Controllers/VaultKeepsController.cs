using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(VaultKeepersService vaultKeepersService, Auth0Provider auth0Provider)
  {
    _vaultKeepersService = vaultKeepersService;
    _auth0Provider = auth0Provider;
  }
  private readonly VaultKeepersService _vaultKeepersService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeeps>> CreateVK([FromBody] VaultKeeps vaultKeeperData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultKeeperData.CreatorId = userInfo.Id;
      VaultKeeps vaultKeeper = _vaultKeepersService.CreateVK(vaultKeeperData);
      return Ok(vaultKeeper);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [HttpGet]
  // public ActionResult<List<VaultKeeper>> GetAll()
  // {
  //   try 
  //   {
  //   List<VaultKeeper> vaultKeeper = _vaultKeepersService.GetAll();
  //   return Ok(vaultKeeper);
  //   }
  //   catch (Exception exception)
  //   {
  //     return BadRequest(exception.Message);
  //   }
  // }


}