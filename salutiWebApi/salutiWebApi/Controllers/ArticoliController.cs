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

      var articoli = await _articoliRepository.SelArticoliByDescrizione(Descrizione);

      // guard codiction
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (articoli.Count() == 0)
      {
        // ritrno errore 404
        return NotFound(string.Format(articoloNonTrovato, Descrizione, nameof(Descrizione)));

      }

      // code

      foreach (var articolo in articoli)
      {
        articoliDto.Add(new ArticoliDto
        {
          CodArt = articolo.CodArt,
          Descrizione = articolo.Descrizione,
          Um = articolo.Um,
          IdStatoArt = articolo.IdStatoArt,
          PzCart = articolo.PzCart,
          PesoNetto = articolo.PesoNetto,
          DataCreazione = articolo.DataCreazione,
          IvaDto = new IvaDto(articolo.iva.Descrizione , articolo.iva.Aliquota),
          Categoria = articolo.famAssort.Descrizione,
        });
      }


      return Ok(articoliDto);
    }

    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(Articoli))]
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

      var barcodeDto = new List<BarcodeDto>();

      foreach (var barcodeArticoli in articolo.Barcode)
      {
        barcodeDto.Add(new BarcodeDto
        {
          Barcode = barcodeArticoli.BarCode,
          Tipo = barcodeArticoli.IdTipoArt,
        }) ;
      }

      var articoliDto = new ArticoliDto
      {
        CodArt = articolo.CodArt,
        Descrizione = articolo.Descrizione,
        Um = articolo.Um,
        IdStatoArt = articolo.IdStatoArt,
        PzCart = articolo.PzCart,
        PesoNetto = articolo.PesoNetto,
        DataCreazione = articolo.DataCreazione,
        BarcodeDto = barcodeDto,
        IvaDto = new IvaDto(articolo.iva.Descrizione , articolo.iva.Aliquota),
        Categoria = articolo.famAssort.Descrizione,
      };

      return Ok(articoliDto);
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

      var articoloDto = new ArticoliDto
      {
        CodArt = articolo.CodArt,
        Descrizione = articolo.Descrizione,
        Um = articolo.Um,
        IdStatoArt = articolo.IdStatoArt,
        PzCart = articolo.PzCart,
        PesoNetto = articolo.PesoNetto,
        DataCreazione = articolo.DataCreazione,
        IvaDto = new IvaDto(articolo.iva.Descrizione , articolo.iva.Aliquota),
        Categoria = articolo.famAssort.Descrizione,
      };

      return Ok(articoloDto);
    }

  }
}
