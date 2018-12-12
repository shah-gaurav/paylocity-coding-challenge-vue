using Paylocity.CodingChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IDeductionCalculator
    {
        decimal CalculateDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear);
        decimal CalculateDeductionPerAnnum(List<Person> persons);
        decimal CalculateDeductionWithDiscount(Person person);
    }
}
