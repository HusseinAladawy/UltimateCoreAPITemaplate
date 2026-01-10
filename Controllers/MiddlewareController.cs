using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UltimateCoreAPITemaplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddlewareController : ControllerBase
    {
        // GET: api/<MiddlewareController>
        [HttpGet]
        public ActionResult Get()
        {
            HttpContext context = HttpContext;
           return Ok(context.Features.);
        }

       
    }
}
