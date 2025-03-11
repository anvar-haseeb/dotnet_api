using Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomController : ControllerBase
    {
        private readonly IRandomNumberService _randomNumberService1;
        private readonly IRandomNumberService _randomNumberService2;
        public RandomController(IRandomNumberService randomNumberService1, IRandomNumberService randomNumberService2)
        {
            _randomNumberService1 = randomNumberService1;
            _randomNumberService2 = randomNumberService2;
        }
        [HttpGet]
        public IActionResult GetRandomNumbers()
        {
            return Ok(new {
                FirstInstance = _randomNumberService1.GetRandomNumber(),
                SecondInstance = _randomNumberService2.GetRandomNumber()
            });
        }
        [HttpPost]
        public IActionResult postRandomNumber(int number)
        {
            if (number == 5) { 
            throw new ArgumentOutOfRangeException(nameof(number));
            }
            return Ok("Post");
        }
    }
}
