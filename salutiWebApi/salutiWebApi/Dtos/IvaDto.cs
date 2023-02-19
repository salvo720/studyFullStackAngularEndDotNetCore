using System;

namespace salutiWebApi.Dtos
{
  public class IvaDto
  {

    public string Descrizione { get; set; }

    public Int16 Aliquota { get; set; }

    public IvaDto(string Descrizione, Int16 Aliquota)
    {
      this.Descrizione= Descrizione;
      this.Aliquota = Aliquota;
    }
  }

  
}
