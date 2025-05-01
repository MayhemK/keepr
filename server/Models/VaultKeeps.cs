namespace keepr.Models;

public class VaultKeeps : RepoItems<int>
{
  public string CreatorId { get; set; }
  public int VaultId { get; set; }
  public int KeepId { get; set; }
}


public class VaultKeepsProfile : Profile
{
  public int VaultKeepsId { get; set; }
  public int VaultId { get; set; }

}


public class VKModel : RepoItems<int>
{
  public int VaultKeepId { get; set; }
  public int VaultId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}
