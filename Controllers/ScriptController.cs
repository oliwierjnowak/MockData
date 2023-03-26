using Microsoft.AspNetCore.Mvc;
using MockData.Model;

namespace MockData.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class ScriptController : Controller
    {
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            return new FishDb().Script;
        }
    }
}
