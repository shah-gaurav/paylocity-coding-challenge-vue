﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Code
{
    [ExcludeFromCodeCoverage]
    public class Constants
    {
        public const decimal EMPLOYEE_DEDUCTION_PER_YEAR = 1000;
        public const decimal DEPENDENT_DEDUCTION_PER_YEAR = 500;
        public const decimal TEN_PERCENT_DISCOUNT_RATE = 0.10M;
        public const decimal ZERO_PERCENT_DISCOUNT_RATE = 0.0M;
    }
}
