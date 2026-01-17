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
            int[]  x = { 1, 2, 3, 4, 5 };
            x[10] = 100; // This will cause an unhandled exception

            return Ok(context.User);
        }

       
    }
}
