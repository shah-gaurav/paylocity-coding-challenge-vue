using Paylocity.CodingChallenge.Entities;
using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.Code
{
    public interface IEmployeeToPersonListConverter
    {
        List<Entities.Person> Convert(Employee employee);
    }
}
