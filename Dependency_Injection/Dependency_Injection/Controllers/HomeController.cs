using Dependency_Injection.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmailSenderServices _service;
        public HomeController(IEmailSenderServices service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _service.SendEmail("Hello World");
            return Ok("Hello");
        }
    }
}
