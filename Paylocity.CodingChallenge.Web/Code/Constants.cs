using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.Code
{
    [ExcludeFromCodeCoverage]
    public class Constants
    {
        public const int SALARY_PER_PAYCHECK = 2000;
        public const int NUMBER_OF_PAYCHECKS_PER_YEAR = 26;

        public const string INDEX_PAGE = "/Index";
        public const string EMPLOYEE_INFORMATION_PAGE = "/EmployeeInformation";
        public const string RESULTS_PAGE = "/Results";

        public const string RESULTS_TEMP_DATA_KEY = "CalculationResults";
    }
}
