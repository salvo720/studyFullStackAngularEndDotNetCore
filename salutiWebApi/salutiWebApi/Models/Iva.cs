using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class Iva
  {
    [Key]
    public int IdIva { get; set; }

    public string? Descrizione { get; set; }

    [Required]
    public int Aliquota { get; set; }

    //relazione : 1 iva corrisponde a molti articoli
    public virtual ICollection<Articoli>? articoli { get; set; }
  }
}
