using salutiWebApi.Models;
using System;

namespace salutiWebApi.Service
{

  public interface IArticoliRepository
  {
    //Selezone
    Task<IEnumerable<Articoli>> SelArticoliByDescrizione(string Descrizione);

    Task<Articoli> SelArticoloByCodice(string Codice);
    Task<Articoli> SelArticoloByEan(string Ean);

    //update e insert e delete

    bool InsertArticoli(Articoli articolo);
    bool UpdateArticoli(Articoli articolo);
    bool DeleteArticoli(Articoli articolo);
    bool Salva( );

    //verifica se esiste un articolo 
    Task<bool> ArticoloExists(string Codice);

  }
}

