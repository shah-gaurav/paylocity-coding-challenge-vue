using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.ViewModels
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
