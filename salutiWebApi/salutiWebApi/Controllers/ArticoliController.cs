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

    public ArticoliController(IArticoliRepository articoliRepository)
    {
      // qui viene effettuato il codeInjection della classe IArticoliRepository
      _articoliRepository = articoliRepository;
    }


    [HttpGet("cerca/descrizione/{filter}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ArticoliDto>))]

    public async Task<IActionResult> GetArticoliByDesc(string filter)
    {
      // IActionResult indica che otteremo degli articoli in formato json e anche uno stato
      // che ritornera una bad request se qualcosa non e andata per il verso giusto
      var articoliDto = new List<ArticoliDto>();

      var articoli = await _articoliRepository.SelArticoliByDescrizione(filter);

      // guard codiction
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (articoli.Count() == 0)
      {
        // ritrno errore 404
        return NotFound(string.Format("Non e stato trovato alcun articolo con il filtro '{0}'", filter));
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
        });
      }


      return Ok(articoliDto);
    }
  }
}
