using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.Services
{
    public interface IDeductionCalculationService
    {
        DeductionCalculationResults CalculateDeductions(Employee employee);
    }
}
