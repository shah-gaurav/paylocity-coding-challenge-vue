using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paylocity.CodingChallenge.Entities;
using Paylocity.CodingChallenge.Entities.Enums;
using Paylocity.CodingChallenge.Web.ViewModels;

namespace Paylocity.CodingChallenge.Web.Code
{
    public class EmployeeToPersonListConverter : IEmployeeToPersonListConverter
    {
        public List<Entities.Person> Convert(Employee employee)
        {
            var returnList = new List<Entities.Person>();

            returnList.Add(new Entities.Person() { Name = employee.Name, Type = Entities.Enums.PersonType.Employee });

            foreach (var dependent in employee.Dependents)
            {
                returnList.Add(new Entities.Person() { Name = dependent.Name, Type = GetPersonTypeFromDependentType(dependent.Type) });
            }

            return returnList;
        }

        private PersonType GetPersonTypeFromDependentType(DependentType type)
        {
            switch (type)
            {
                case DependentType.Child:
                    return PersonType.Child;
                case DependentType.Spouse:
                    return PersonType.Spouse;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
