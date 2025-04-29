namespace keepr.Models;

public class VaultKeeps : RepoItems<int>
{
  public string CreatorId { get; set; }
  public int VaultId { get; set; }
  public int KeepId { get; set; }
}