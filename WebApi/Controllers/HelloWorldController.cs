using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        InterfaceHelloWorldService IHelloWord;
       
        private readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(InterfaceHelloWorldService IHelloWorldService, ILogger<HelloWorldController> logger)
        {
            IHelloWord = IHelloWorldService;
            _logger = logger;
        }

        [HttpGet]
        [Route("gethello")]
        public ActionResult GetHelloWorld()
        {
            _logger.LogInformation("Devolviendo hello word");
            return Ok(IHelloWord.GetHelloWorld());
        }
    }
}
