using Microsoft.AspNetCore.Mvc;
using PatikaExample1.IServices;

namespace PatikaExample1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;
        public InterestController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }


    }
}
