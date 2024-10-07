using MathApiService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService<double> _calculatorService;

        public CalculatorController(ICalculatorService<double> calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        public ActionResult<double> Add([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(_calculatorService.Add(a, b));
        }

        [HttpGet("subtract")]
        public ActionResult<double> Subtract([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(_calculatorService.Subtract(a, b));
        }

        [HttpGet("multiply")]
        public ActionResult<double> Multiply([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(_calculatorService.Multiply(a, b));
        }

        [HttpGet("divide")]
        public ActionResult<double> Divide([FromQuery] double a, [FromQuery] double b)
        {
            try
            {
                return Ok(_calculatorService.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
