using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.ViewModels
{
    public enum DependentType
    {
        Spouse,
        Child
    }

    [ExcludeFromCodeCoverage]
    public class Dependent : Person
    {
        [Required]
        public DependentType Type { get; set; }
    }
}
