using Microsoft.AspNetCore.Mvc;

namespace salutiWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class SalutiController : Controller
    {

        public string getSaluti()
        {
            string stringa = "\"Saluti , sono la tua prima web api\"";
            return stringa;
        }

        //usando le parentesi graffe andremo ad indicare una variabile e deve avere lo 
        //stesso nome al del parametro che andiamo a passare al metodo , è caseSensitive 
        [HttpGet("{Nome}")]
        public string getSaluti(string Nome)
        {
            string stringa = string.Format("\"Saluti , {0} sono la tua prima web api c# 6.0 \"", Nome);
            return stringa;
        }

        

        public IActionResult Index()
        {
            return View();
        }
    }
}
