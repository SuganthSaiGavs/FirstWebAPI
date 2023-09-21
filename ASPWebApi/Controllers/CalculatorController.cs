using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApi.Controllers
{ //Is it changing in local
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
/*        [HttpGet("/add")]  //if you add '/' it becomes root
       // [HttpGet] 
        public int Add(int x, int y)
        {
            return x + y;
        }*/

        [HttpGet("calculator/add")]  //if you add '/' it becomes root
                           // [HttpGet]
        public int Add(int x, int y)
        {
            return x + y;
        }
        // api/calculator/subract? x=10 & y=5
        [HttpGet("calculator/sum")]
        public int Sum(int x, int y)
        {
            return x + y+1000;
        }
        // api/calculator/multiply? x=10 & y=10
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/calculator/add? x=10 & y=2
        [HttpDelete]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
