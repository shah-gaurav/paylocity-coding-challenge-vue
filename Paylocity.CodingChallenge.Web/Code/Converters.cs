using Paylocity.CodingChallenge.Entities.Enums;
using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.Code
{
    public static class Converters
    {
        public static List<Entities.Person> ConvertEmployeeToPersonList(Employee employee)
        {
            var returnList = new List<Entities.Person>();

            returnList.Add(new Entities.Person() { Name = employee.Name, Type = Entities.Enums.PersonType.Employee });

            foreach (var dependent in employee.Dependents)
            {
                returnList.Add(new Entities.Person() { Name = dependent.Name, Type = ConvertDependentTypeToPersonType(dependent.Type) });
            }

            return returnList;
        }

        public static PersonType ConvertDependentTypeToPersonType(DependentType type)
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
