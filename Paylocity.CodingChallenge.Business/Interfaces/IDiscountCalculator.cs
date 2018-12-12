using Paylocity.CodingChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IDiscountCalculator
    {
        decimal GetDiscountRate(Person person);
    }
}
