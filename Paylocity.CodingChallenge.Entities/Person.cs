using Paylocity.CodingChallenge.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Paylocity.CodingChallenge.Entities
{
    [ExcludeFromCodeCoverage]
    public class Person
    {
        public string Name { get; set; }
        public PersonType Type { get; set; }
    }
}
