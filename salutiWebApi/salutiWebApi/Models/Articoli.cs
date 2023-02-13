using System.ComponentModel.DataAnnotations;

namespace salutiWebApi.Models
{
  public class Articoli
  {
    [Key] //indica una chiave primaria
    [MinLength(5, ErrorMessage = "Il numero minimo di caratteri e 5")] //indica ala lunghezza minima 
    [MaxLength(30, ErrorMessage = "Il numero massimo di caratteri e 30")] //indica ala lunghezza massima
    public string CodArt { get; set; }

    [MinLength(5, ErrorMessage = "Il numero minimo di caratteri e 5")] //indica ala lunghezza minima 
    [MaxLength(80, ErrorMessage = "Il numero massimo di caratteri e 80")] //indica ala lunghezza massima
    public string Descrizione { get; set; }

    public string Um { get; set; }

    [Range(0,100 , ErrorMessage="I pezzi per cartone devono essere compresi tra 0 e 100")] // indica un valore compreso nel range 0 - 100 
    public int? PzCart { get; set; }

    [Range(0, 100, ErrorMessage = "I pezzi per cartone devono essere compresi tra 0 e 100")] // indica un valore compreso nel range 0 - 100 
    public double? PesoNetto { get; set; }
    public int? IdIva { get; set; }
    public int? IdFamAss { get; set; }
    public string IdStatoArt { get; set; }
    public DateTime? DataCreazione { get; set; }
  }
}
