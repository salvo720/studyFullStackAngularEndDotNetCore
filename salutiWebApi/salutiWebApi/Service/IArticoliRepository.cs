using salutiWebApi.Models;
using System;

namespace salutiWebApi.Service
{

  public interface IArticoliRepository
  {
    //Selezone
    ICollection<Articoli> SelArticoliByDescrizione(string Descrizione);

    Articoli SelArticoloByCodice(string Codice);
    Articoli SelArticoloByEan(string Ean);

    //update e insert e delete

    bool InsertArticoli(Articoli articolo);
    bool UpdateArticoli(Articoli articolo);
    bool DeleteArticoli(Articoli articolo);
    bool Salva( );

    //verifica se esiste un articolo 
    bool ArticoloExists(string Codice);

  }
}

