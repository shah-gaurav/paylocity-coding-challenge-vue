using Paylocity.CodingChallenge.Business.Code;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business
{
    public class AnnualDeductionRate : IAnnualDeductionRate
    {
        public decimal Get(PersonType personType)
        {
            switch (personType)
            {
                case Entities.Enums.PersonType.Employee:
                    return Constants.EMPLOYEE_DEDUCTION_PER_YEAR;
                case Entities.Enums.PersonType.Spouse:
                case Entities.Enums.PersonType.Child:
                    return Constants.DEPENDENT_DEDUCTION_PER_YEAR;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
