using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        [HttpGet("/")]
        public ActionResult Home()
        {
           return  Ok("Bem Vind(a) api de livros");
        }
    }
}
