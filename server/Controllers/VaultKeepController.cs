namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepController : ControllerBase
{
  public VaultKeepController(VaultKeepersService vaultKeepersService, Auth0Provider auth0Provider)
  {
    _vaultKeepersService = vaultKeepersService;
    _auth0Provider = auth0Provider;
  }
  private readonly VaultKeepersService _vaultKeepersService;
  private readonly Auth0Provider _auth0Provider;
}