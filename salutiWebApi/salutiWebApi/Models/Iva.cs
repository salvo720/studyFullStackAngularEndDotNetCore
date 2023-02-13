using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class Iva
  {
    [Key]
    public int IdIva { get; set; }

    public string Descrizione { get; set; }

    [Required]
    public int Aliquota { get; set; }
  }
}
