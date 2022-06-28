using Microsoft.AspNetCore.Mvc;
using PatikaExample1.IServices;
using PatikaExample1.Models;
using System.ComponentModel;

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="interestRate">(Faiz oranı)</param>
        /// <param name="totalAmount">(Ana Para)</param>
        /// <param name="period">(Yıl)</param>
        /// <returns></returns>
        /// <response code="200">Retuns data </response>
        /// <response code="400">Returns error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseModel<InterestModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel<InterestModel>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateInterest(double? interestRate, [Description("Ana para")]int? totalAmount, int? period)
        {
            var data = await Task.Run(() => _interestService.CalculateInterest(interestRate, totalAmount, period));

            if (String.Equals("System.ArgumentNullException", data.GetType().FullName))
            {
                var error = data as ArgumentNullException;
                return BadRequest(new ResponseModel<InterestModel>
                {
                    metaData = new MetaData
                    {
                        Message = error.ParamName,
                        Success = false
                    },
                    data = data as InterestModel
                    
                });
            }
            return Ok(new ResponseModel<InterestModel>
            {
                metaData = new MetaData
                {
                    Message = null,
                    Success = true
                },
                data = data as InterestModel
            });
        }


    }
}
