using Paylocity.CodingChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IDeductionCalculator
    {
        double CalculateDeductionPerPaycheck(List<Person> people, int numberOfPaychecksPerYear);
        double CalculateDeductionPerAnnum(List<Person> people);
        double CalculateDeductionWithDiscount(Person person);
    }
}
