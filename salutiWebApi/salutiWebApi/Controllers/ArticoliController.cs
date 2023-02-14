using Microsoft.AspNetCore.Mvc;
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
    [ProducesResponseType(200 , Type = typeof(IEnumerable<Articoli>))]

    public IActionResult GetArticoliByDesc(string filter)
    {
      // IActionResult indica che otteremo degli articoli in formato json e anche uno stato 
      // che ritornera una bad request se qualcosa non e andata per il verso giusto 
      var articoli = _articoliRepository.SelArticoliByDescrizione(filter);

      return Ok(articoli);
    }
  }
}
