using Microsoft.EntityFrameworkCore;
using salutiWebApi.Models;
using System.Linq;

namespace salutiWebApi.Service

  // questa parte di service o model viene definito come strato di persistenza 
{
  public class ArticolyRepository : IArticoliRepository
  {
    AlphaShopDbContex _alphaShopDbContex;

    public ArticolyRepository(AlphaShopDbContex alphaShopDbContex)
    {
      _alphaShopDbContex = alphaShopDbContex;
      // il codice sotto e equvalente uso il _ perche dotnet nel generare il
      // file segue questa sintassi 
      // this._alphaShopDbContex = alphaShopDbContex;
    }

    public IEnumerable<Articoli> SelArticoliByDescrizione(string Descrizione)
    {
      return _alphaShopDbContex.Articoli
        .Where(a => a.Descrizione!.Contains(Descrizione) )
        .OrderBy( a => a.Descrizione)
        .ToList();
      // usiamo alla fine to list perche e una ICollection , ( collezione di classi articoli ) 
    }

    public Articoli SelArticoloByCodice(string Codice)
    {
      return _alphaShopDbContex.Articoli
        .Where(a => a.CodArt!.Equals(Codice))
        .OrderBy(a => a.CodArt)
        .FirstOrDefault()!;
      //FirstorDefault si utilizza quando si ha soltato un elemento di una classe ,
      // indica lavora secondo la logica se lo trovi lo restituisci , altrimenti non restiusci nulla 

    }

    public Articoli SelArticoloByEan(string Ean)
    {
      // fai attenzione a questa query , qui partiamo selezionando il barcode ,
      // successivamente grazie al select selezioniamo dal barcode anche l'articolo
      // infine FirstOrDefault ritrno l'elemnto se lo trova altrimenti non tornera nulla 

      return _alphaShopDbContex.BarCode
        .Where(b => b.BarCode!.Equals(Ean))
        .Select(a => a.articolo)
        .FirstOrDefault()!;
    }
    public bool InsertArticoli(Articoli articolo)
    {
      throw new NotImplementedException();
    }
    public bool UpdateArticoli(Articoli articolo)
    {
      throw new NotImplementedException();
    }

    public bool DeleteArticoli(Articoli articolo)
    {
      throw new NotImplementedException();
    }

    public bool Salva()
    {
      throw new NotImplementedException();
    }

   

  

    public bool ArticoloExists(string Codice)
    {
      throw new NotImplementedException();
    }



  }
}
