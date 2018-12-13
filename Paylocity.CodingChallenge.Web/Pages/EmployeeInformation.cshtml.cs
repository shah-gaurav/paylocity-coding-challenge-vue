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

        [BindProperty]
        public Employee Employee { get; set; }

        public List<SelectListItem> DependentTypeList { get; } = new List<SelectListItem>();

        public DeductionCalculationResults CalcuationResults { get; private set; }

        public EmployeeInformationModel(IDeductionCalculationService deductionCalculationService)
        {
            _deductionCalculationService = deductionCalculationService;

            PopulateDependentTypeList();
        }

        #region HTTP Actions
        public IActionResult OnGet(int? numberOfDependents)
        {
            if (numberOfDependents == null)
            {
                return RedirectToPage("/Index");
            }

            Employee = CreateEmployeeViewModel(numberOfDependents);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CalcuationResults = _deductionCalculationService.CalculateDeductions(Employee);

            return Page();
        }
        #endregion

        private void PopulateDependentTypeList()
        {
            foreach (var value in Enum.GetValues(typeof(DependentType)))
            {
                DependentTypeList.Add(new SelectListItem(value.ToString(), value.ToString()));
            }
        }

        private Employee CreateEmployeeViewModel(int? numberOfDependents)
        {
            var employee = new Employee();

            employee.YearlySalary = SALARY_PER_PAYCHECK * NUMBER_OF_PAYCHECKS_PER_YEAR;
            employee.NumberOfPaychecksPerYear = NUMBER_OF_PAYCHECKS_PER_YEAR;

            for (int i = 0; i < numberOfDependents; i++)
            {
                employee.Dependents.Add(new Dependent() { Type = (i == 0 ? DependentType.Spouse : DependentType.Child) });
            }

            return employee;
        }
    }
}