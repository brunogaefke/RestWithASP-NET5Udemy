using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Get(string FirstNumber, string SecondNumber)
        {
            if (IsNumeric(FirstNumber) && (IsNumeric(SecondNumber)))
            {
                var sum = ConvertToDecimal(FirstNumber) + ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool IsNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return IsNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal DecimalValue;
            if(decimal.TryParse(strNumber, out DecimalValue))
            {
                return DecimalValue;
            }
            return 0;
        }

    }
}
