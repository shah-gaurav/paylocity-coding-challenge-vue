using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paylocity.CodingChallenge.Web.Services;
using Paylocity.CodingChallenge.Web.ViewModels;

namespace Paylocity.CodingChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsCalculatorController : ControllerBase
    {
        private readonly IDeductionCalculationService _deductionCalculationService;

        public BenefitsCalculatorController(IDeductionCalculationService deductionCalculationService)
        {
            _deductionCalculationService = deductionCalculationService;
        }

        [HttpPost]
        public ActionResult<DeductionCalculationResults> Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return _deductionCalculationService.CalculateDeductions(employee);
        }
    }
}