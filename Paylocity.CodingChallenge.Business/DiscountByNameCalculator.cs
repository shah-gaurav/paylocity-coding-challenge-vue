using System;
using System.Collections.Generic;
using System.Text;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities;

namespace Paylocity.CodingChallenge.Business
{
    public class DiscountByNameCalculator : IDiscountCalculator
    {
        public double GetDiscountRate(Person person)
        {
            if (person?.Name?.ToLower().StartsWith("a") ?? false)
                return 0.10; // 10 percent discount rate
            else
                return 0; // no discount
        }
    }
}
