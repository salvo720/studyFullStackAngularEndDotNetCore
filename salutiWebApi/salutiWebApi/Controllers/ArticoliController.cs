using Microsoft.AspNetCore.Mvc;
using salutiWebApi.Dtos;
using salutiWebApi.Models;
using salutiWebApi.Service;

namespace salutiWebApi.Controllers
{
  [ApiController]
  [Produces("application/json")]
  [Route("api/articoli")]
  public class ArticoliController : Controller
  {
    // Dependency inject :
    // ovvero stiamo iniettando all'interno della nostra classe una classe dipendenza
    // da notare che abbiamo usato un interfaccia , e questo ci permette di creare diverse classi di implementazione e decide dopo quali attivare
    // la dependecy inject che si puo effetturare su un progetto Asp.net core 6.0 dipende dal metodo ConfigureService su program dove troviamo il metodo AddScoped
    // Dove andremo a specificare il servizio e la relativa classe di implmentazione

    //Abbiamo 3 Tipologie di dependecy Injection e dipende dal ciclo di vita dei nostri servizi e sono :
    // 1) Transient : I servizi vengono creati tutte le volte che sono iniettati o richiesti
    // 2) Scoped : i servizi vengono creati per ogni richiesta web
    // 3) SingleTon : i servizi vengono creati una volta soltanto per applicazione e vengono usati fino alla terminazione della stessa

    // Dopo che un servizio ha terminato il suo ciclo di vita le risorse vengono rilascite .

    // L'ordine di preferenza di quali isntaziare corrisponde a quello su ,
    // ovvero e preferibile instazioare un service : Transient>Scoped>Singleton ;

    // 1) posizione Transiente , perche crea i servizi tutti le volte che vengono iniettati e richiesti

    // 2) posizione abbiamo gli Scoped perche si basa sulla richiesta web e una volta che la richiesta
    // e terminata termina anche il ciclo di vita del servizio

    // 3) posizione troviamo il SingleTon , perche il SingleTon da problemi di consumo di memoria ,
    // perche solo dopo che terminano il loro ciclo di vita le risorse vengono rilascite
    // ma utilizzadno un SingleTon questo non capita mai perche dopo che i servizi vengono creati vengono gestiti a livello di applicazine

    // ma dove e che specifichiamo quale tipo di dependecy injection usare ?
    // Siamo noi a poter decidere il ciclo di vita dei nostri servizi nel file program dell'applciazione
    // per trovare la parte di dependcy inject ci basta cercare service.Add + tipologia del servizio , ad esempio services.AddScoped<Interfacciao,Classe>();
    // esempio attuale nell'applicazione : service.AddScoped<IArticoliRepository,ArticoliRepository>();

    // Quando su un controller si usa la depedency Injection bisogna far precedere sempre usare readonly sulla variabile del depency Injection , che quindi sara (esempio attuale ) :
    // private readonly IArticoliRepository articoliRepository ,
    // NotaBene : con il codice alla riga su creiamo un attributo nella classe controller di tipo interfaccia e su program andiamo a dire chi e la classe da instanziare e la tipologia di servizio

    private readonly IArticoliRepository _articoliRepository;
    private readonly string articoloNonTrovato = "\" Non e stato trovato alcun articolo con il {0} '{1}' \"";

    public ArticoliController(IArticoliRepository articoliRepository)
    {
      // qui viene effettuato il codeInjection della classe IArticoliRepository
      _articoliRepository = articoliRepository;
    }


    [HttpGet("cerca/descrizione/{descrizione}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ArticoliDto>))]

    public async Task<IActionResult> GetArticoliByDesc(string descrizione)
    {
      // IActionResult indica che otteremo degli articoli in formato json e anche uno stato
      // che ritornera una bad request se qualcosa non e andata per il verso giusto
      var articoliDto = new List<ArticoliDto>();

      // guard codiction
      // il secondo caso e quello in cui la descrizione e un char
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var articoli = await _articoliRepository.SelArticoliByDescrizione(descrizione);

      if ( articoli == null || articoli.Count() == 0)
      {
        // ritrno errore 404
        return NotFound(string.Format(articoloNonTrovato, nameof(descrizione) , descrizione));

      }

      // code

      foreach (var articolo in articoli)
      {
        if(articolo != null){

        articoliDto.Add(GetArticoloByDto(articolo));
        }
      }
      return Ok(articoliDto);
    }

    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(ArticoliDto))]
    [HttpGet("cerca/codice/{codArt}")]
    public async Task<IActionResult> GetArticoliByCodice(string codArt)
    {
      // gestiamo il caso in cui l'articolo non esiste

      bool ricercaArticolo = await this._articoliRepository.ArticoloExists(codArt);
      if (!ricercaArticolo)
      {
        return NotFound(string.Format(articoloNonTrovato, nameof(codArt) , codArt));

      }
      var articolo = await _articoliRepository.SelArticoloByCodice(codArt);

      return Ok(this.GetArticoloByDto(articolo));
    }

    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(ArticoliDto))]
    [HttpGet("cerca/barcode/{barcode}")]
    public async Task<IActionResult> GetArticoloByEan(string barcode)
    {
      // gestione articolo non trovato
      var articolo = await _articoliRepository.SelArticoloByEan(barcode);

      if (articolo == null)
      {
        return NotFound(string.Format(articoloNonTrovato, nameof(barcode) , barcode));
      }

      return Ok(this.GetArticoloByDto(articolo));
    }

    public ArticoliDto GetArticoloByDto(Articoli articolo)
    {
      //Console.WriteLine(articolo.CodArt);
      var barcodeDto = new List<BarcodeDto>();

      foreach (var barcodeArticolo in articolo.barcode)
      {
        barcodeDto.Add(new BarcodeDto
        {
          Barcode = barcodeArticolo.BarCode,
          Tipo = barcodeArticolo.IdTipoArt,
        });
      }

      var articoloDto = new ArticoliDto
      {
        CodArt = articolo.CodArt,
        Descrizione = articolo.Descrizione,
        Um = articolo.Um?.Trim(), // Trim() usato sulle stringhe rimuove gli spazi quando sono >1
        IdStatoArt = articolo.IdStatoArt?.Trim(),
        PzCart = articolo.PzCart,
        PesoNetto = articolo.PesoNetto,
        DataCreazione = articolo.DataCreazione,
        BarcodeDto = barcodeDto,
        IvaDto = new IvaDto(articolo.iva.Descrizione, articolo.iva.Aliquota),
        Categoria = articolo.famAssort.Descrizione,
      };

      return articoloDto;
    }

  }
}
