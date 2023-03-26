using Microsoft.AspNetCore.Mvc;

namespace MockData.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class ScriptController : Controller
    {
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            return "Hello world \n loool";
        }
    }
}
