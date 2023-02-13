using System;
using System.ComponentModel.DataAnnotations;

namespace salutiWebApi
{

  public class Ean
  {
    public string CodArt { get; set; }

    [Key]
    [StringLength(13,MinimumLength=8, ErrorMessage="Il BarCode deve avere da 8 a 13 cifre")] // notazione alternavita con dentro insieme valore massimo e minimo 
    public string BarCode { get; set; }

    [Required] // non ammette valori Null
    public string IdTipoArt { get; set; }
  }
}

