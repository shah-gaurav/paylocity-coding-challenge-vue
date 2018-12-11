using Paylocity.CodingChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IDeductionCalculator
    {
        double CalculateDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear);
        double CalculateDeductionPerAnnum(List<Person> persons);
        double CalculateDeductionWithDiscount(Person person);
    }
}
