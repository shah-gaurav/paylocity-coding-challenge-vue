using System;
using System.Collections.Generic;
using System.Text;
using Paylocity.CodingChallenge.Business.Code;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities;

namespace Paylocity.CodingChallenge.Business
{
    public class DiscountByNameCalculator : IDiscountCalculator
    {
        public decimal GetDiscountRate(Person person)
        {
            if (person?.Name?.ToLower().StartsWith("a") ?? false)
                return Constants.TEN_PERCENT_DISCOUNT_RATE; // 10 percent discount rate
            else
                return Constants.ZERO_PERCENT_DISCOUNT_RATE; // no discount
        }
    }
}
