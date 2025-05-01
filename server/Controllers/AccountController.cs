namespace keepr.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultKeepersService _vaultKeepersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultKeepersService vaultKeepersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _vaultKeepersService = vaultKeepersService;

  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
