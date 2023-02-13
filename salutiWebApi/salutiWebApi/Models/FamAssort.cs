using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class FamAssort
  {
    [Key]
    public int Id { get; set; }

    public string Descrizione { get; set; }
  }
}
