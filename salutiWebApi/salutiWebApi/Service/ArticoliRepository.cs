using Microsoft.EntityFrameworkCore;
using salutiWebApi.Models;
using System.Linq;

namespace salutiWebApi.Service

  // questa parte di service o model viene definito come strato di persistenza 
{
  public class ArticoliRepository : IArticoliRepository
  {
    AlphaShopDbContex _alphaShopDbContex;

    public ArticoliRepository(AlphaShopDbContex alphaShopDbContex)
    {
      _alphaShopDbContex = alphaShopDbContex;
      // il codice sotto e equvalente uso il _ perche dotnet nel generare il
      // file segue questa sintassi 
      // this._alphaShopDbContex = alphaShopDbContex;
    }

    // il metodo adesso e asincrono 
    public  async Task<IEnumerable<Articoli>> SelArticoliByDescrizione(string Descrizione)
    {
      return await _alphaShopDbContex.Articoli
        .Where(a => a.Descrizione!.Contains(Descrizione) )
        .Include(a => a.IdIva)
        .Include(a => a.famAssort)
        .Include(a => a.Barcode)
        .OrderBy( a => a.Descrizione)
        .ToListAsync();
      // usiamo alla fine to list perche e una ICollection , ( collezione di classi articoli ) 
    }

    public async Task<Articoli> SelArticoloByCodice(string Codice)
    {
      return await _alphaShopDbContex.Articoli
        .Where(a => a.CodArt!.Equals(Codice))
        .OrderBy(a => a.CodArt)
        .Include(a => a.Barcode) // include i dati della tabella relazionale tramite la chiave esterna 
        .Include(a => a.famAssort)
        .Include(a => a.iva)
        .FirstOrDefaultAsync();
      //FirstorDefault si utilizza quando si ha soltato un elemento di una classe ,
      // indica lavora secondo la logica se lo trovi lo restituisci , altrimenti non restiusci nulla 

    }

    public async Task<Articoli> SelArticoloByEan(string Ean)
    {
      // fai attenzione a questa query , qui partiamo selezionando il barcode ,
      // successivamente grazie al select selezioniamo dal barcode anche l'articolo
      // infine FirstOrDefault ritrno l'elemnto se lo trova altrimenti non tornera nulla 

      return await _alphaShopDbContex.BarCode
        .Where(b => b.BarCode!.Equals(Ean))
        .Select(a => a.articolo)
        .Include(a => a.IdIva)
        .Include(a => a.famAssort)
        .FirstOrDefaultAsync();
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

    public async Task<bool> ArticoloExists(string Codice)
    {
      return await this._alphaShopDbContex.Articoli
        .AnyAsync( c => c.CodArt == Codice); // any se trova un valore restituisce true , altrimenti ritorna false 
    }



  }
}