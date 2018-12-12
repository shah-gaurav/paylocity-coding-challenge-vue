using Paylocity.CodingChallenge.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IAnnualDeductionRate
    {
        decimal Get(PersonType personType);
    }
}
