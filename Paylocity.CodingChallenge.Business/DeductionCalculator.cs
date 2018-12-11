using System.Collections.Generic;
using System.Linq;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities;

namespace Paylocity.CodingChallenge.Business
{
    public class DeductionCalculator : IDeductionCalculator
    {
        private readonly IAnnualDeductionRate _annualDeductionRate;
        private readonly IDiscountCalculator _discountCalculator;

        public DeductionCalculator(IAnnualDeductionRate annualDeductionRate, IDiscountCalculator discountCalculator)
        {
            _annualDeductionRate = annualDeductionRate;
            _discountCalculator = discountCalculator;
        }

        public double CalculateDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear)
        {
            return CalculateDeductionPerAnnum(persons) / numberOfPaychecksPerYear;
        }

        public double CalculateDeductionPerAnnum(List<Person> persons)
        {
            return persons.Sum(person => CalculateDeductionWithDiscount(person));
        }

        public double CalculateDeductionWithDiscount(Person person)
        {
            return _annualDeductionRate.Get(person.Type) * (1 - _discountCalculator.GetDiscountRate(person));
        }
    }

}
