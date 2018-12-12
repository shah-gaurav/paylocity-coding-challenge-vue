using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities;
using Paylocity.CodingChallenge.Web.Code;
using Paylocity.CodingChallenge.Web.ViewModels;

namespace Paylocity.CodingChallenge.Web.Services
{
    public class DeductionCalculationService : IDeductionCalculationService      
    {
        private readonly IDeductionCalculator _deductionCalculator;
        private readonly IEmployeeToPersonListConverter _employeeToPersonListConverter;

        public DeductionCalculationService(IDeductionCalculator deductionCalculator, IEmployeeToPersonListConverter employeeToPersonListConverter)
        {
            _deductionCalculator = deductionCalculator;
            _employeeToPersonListConverter = employeeToPersonListConverter;
        }

        public DeductionCalculationResults CalculateDeductions(Employee employee)
        {
            List<Entities.Person> persons = _employeeToPersonListConverter.Convert(employee);
            return new DeductionCalculationResults()
            {
                EmployeeDeductionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons.Where(p => p.Type == Entities.Enums.PersonType.Employee).ToList(), employee.NumberOfPaychecksPerYear),
                DependentsDeductionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons.Where(p => p.Type != Entities.Enums.PersonType.Employee).ToList(), employee.NumberOfPaychecksPerYear),
                TotalDeductionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons, employee.NumberOfPaychecksPerYear),
                EmployeeDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons.Where(p => p.Type == Entities.Enums.PersonType.Employee).ToList()),
                DependentsDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons.Where(p => p.Type != Entities.Enums.PersonType.Employee).ToList()),
                TotalDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons)
            };
        }
    }
}
