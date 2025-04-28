using System.ComponentModel.DataAnnotations;

namespace keepr.Models;

public class Keep : RepoItems<int>
{
  public string Name { get; set; }
  [MaxLength(3000)] public string Description { get; set; }
  [Url, MaxLength(1000)] public string Img { get; set; }
  public int Views { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Kept { get; set; }
  public int VaultId { get; set; }
}