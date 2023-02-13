using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class ingredienti
  {
    [Key]
    public int CodArt { get; set; }
    public string Info { get; set; }
  }
}
