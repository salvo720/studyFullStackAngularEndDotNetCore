using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class Ingredienti
  {
    [Key]
    public string? CodArt { get; set; }
    public string? Info { get; set; }

    // relazione con articoli 1 a 1
    public virtual Articoli? articolo { get; set; }
  }
}
