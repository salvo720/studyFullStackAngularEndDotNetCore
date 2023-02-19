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
    private IArticoliRepository _articoliRepository;
    private readonly string articoloNonTrovato = "Non e stato trovato alcun articolo con il {1} '{0}'";

    public ArticoliController(IArticoliRepository articoliRepository)
    {
      // qui viene effettuato il codeInjection della classe IArticoliRepository
      _articoliRepository = articoliRepository;
    }


    [HttpGet("cerca/descrizione/{Descrizione}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ArticoliDto>))]

    public async Task<IActionResult> GetArticoliByDesc(string Descrizione)
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

      var articoli = await _articoliRepository.SelArticoliByDescrizione(Descrizione);
      var barcodeDto = new List<BarcodeDto>();

      if (articoli.Count() == 0 || articoli == null)
      {
        // ritrno errore 404
        return NotFound(string.Format(articoloNonTrovato, Descrizione, nameof(Descrizione)));

      }

      // code

      foreach (var articolo in articoli)
      {
        //Console.WriteLine("articoli " + articolo.famAssort.Descrizione);

        foreach (var articoloBarcode in articolo.barcode!)
        {
          barcodeDto.Add(new BarcodeDto
          {
            Barcode = articoloBarcode.BarCode,
            Tipo = articoloBarcode.IdTipoArt,
          });
        }

        articoliDto.Add(new ArticoliDto
        {
          CodArt = articolo.CodArt,
          Descrizione = articolo.Descrizione,
          Um = articolo.Um,
          IdStatoArt = articolo.IdStatoArt,
          PzCart = articolo.PzCart,
          PesoNetto = articolo.PesoNetto,
          DataCreazione = articolo.DataCreazione,
          BarcodeDto = barcodeDto,
        });
      }
      return Ok(articoliDto);
    }

    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(ArticoliDto))]
    [HttpGet("cerca/codice/{CodArt}")]
    public async Task<IActionResult> GetArticoliByCodice(string CodArt)
    {
      // gestiamo il caso in cui l'articolo non esiste

      bool ricercaArticolo = await this._articoliRepository.ArticoloExists(CodArt);
      if (!ricercaArticolo)
      {
        return NotFound(string.Format(articoloNonTrovato, CodArt, nameof(CodArt)));

      }
      var articolo = await _articoliRepository.SelArticoloByCodice(CodArt);

      return Ok(this.GetArticoloByDto(articolo));
    }

    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(ArticoliDto))]
    [HttpGet("cerca/barcode/{Barcode}")]
    public async Task<IActionResult> GelArticoloByEan(string Barcode)
    {
      // gestione articolo non trovato
      var articolo = await _articoliRepository.SelArticoloByEan(Barcode);

      if (articolo == null)
      {
        return NotFound(string.Format(articoloNonTrovato, Barcode, nameof(Barcode)));
      }

      return Ok(this.GetArticoloByDto(articolo));
    }

    public ArticoliDto GetArticoloByDto(Articoli articolo)
    {

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
        Um = articolo.Um,
        IdStatoArt = articolo.IdStatoArt,
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
