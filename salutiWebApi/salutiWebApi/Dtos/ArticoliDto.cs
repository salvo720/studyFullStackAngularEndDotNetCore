using salutiWebApi.Models;

namespace salutiWebApi.Dtos
{
  //  dto significa : Data Transformation Object 
  // sono le classi in cui i dati vengono modificati , ad esempio possiamo togliere un campo del db dai dati ,
  // ad esempio quando dobbiamo mostrare i dati a schermo tranne alcuni campi 
  public class ArticoliDto
  {
    public string CodArt { get; set; }
    public string Descrizione { get; set; }
    public string Um { get; set; }
    public string IdStatoArt { get; set; }
    public Int16? PzCart { get; set; }
    public double? PesoNetto { get; set; }
    public DateTime? DataCreazione { get; set; }

    // aggiunto per visualizzare i dati della tabella barcode
    public ICollection<BarcodeDto> BarcodeDto { get; set; }

    public IvaDto IvaDto { get; set; }

    public string Categoria { get; set; }
  }


 
}
