using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paylocity.CodingChallenge.Web.Services;
using Paylocity.CodingChallenge.Web.ViewModels;

namespace Paylocity.CodingChallenge.Web.Pages
{
    public class EmployeeInformationModel : PageModel
    {
        private const int SALARY_PER_PAYCHECK = 2000;
        private const int NUMBER_OF_PAYCHECKS_PER_YEAR = 26;
        private readonly IDeductionCalculationService _deductionCalculationService;

        public EmployeeInformationModel(IDeductionCalculationService deductionCalculationService)
        {
            _deductionCalculationService = deductionCalculationService;

            foreach(var value in Enum.GetValues(typeof(DependentType)))
            {
                DependentTypeList.Add(new SelectListItem(value.ToString(), value.ToString()));
            }
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public List<SelectListItem> DependentTypeList { get; } = new List<SelectListItem>();

        public DeductionCalculationResults CalcuationResults { get; private set; }

        public decimal EmployeePaycheckAfterDeductions { get; private set; }
        public decimal EmployeeYearlyPayAfterDeductions { get; private set; }

        public IActionResult OnGet(int? numberOfDependents)
        {
            if (numberOfDependents == null)
            {
                return RedirectToPage("/Index");
            }
            
            Employee = new Employee();

            Employee.YearlySalary = SALARY_PER_PAYCHECK * NUMBER_OF_PAYCHECKS_PER_YEAR;
            Employee.NumberOfPaychecksPerYear = NUMBER_OF_PAYCHECKS_PER_YEAR;

            for (int i = 0; i < numberOfDependents; i++)
            {
                Employee.Dependents.Add(new Dependent() { Type = (i == 0 ? DependentType.Spouse : DependentType.Child) });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            CalcuationResults = _deductionCalculationService.CalculateDeductions(Employee);

            EmployeePaycheckAfterDeductions = (Employee.YearlySalary / (decimal)Employee.NumberOfPaychecksPerYear) - CalcuationResults.TotalDeductionPerPayCheck;
            EmployeeYearlyPayAfterDeductions = Employee.YearlySalary - CalcuationResults.TotalDeductionPerYear;

            return Page();
        }
    }
}