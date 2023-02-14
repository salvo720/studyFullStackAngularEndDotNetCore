using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class FamAssort
  {
    [Key]
    public int Id { get; set; }

    public string? Descrizione { get; set; }

    // relazione : 1 famiglia assortimento corrisponde a molti articoli

    public virtual ICollection<Articoli>? articoli { get; set; }
  }
}
