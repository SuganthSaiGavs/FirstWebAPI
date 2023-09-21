using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("demo/add")] 
        // [HttpGet]
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
