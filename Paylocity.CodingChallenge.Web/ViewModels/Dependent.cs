using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.ViewModels
{
    public enum DependentType
    {
        Spouse,
        Child
    }

    public class Dependent : Person
    {
        [Required]
        public DependentType Type { get; set; }
    }
}
