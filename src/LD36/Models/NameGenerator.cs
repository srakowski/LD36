using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    static class NameGenerator
    {
        public static string GenerateCompanyName(Random rand)
        {
            return "Dolittle Widgets";
        }

        public static string GeneratePersonName(Random rand, Gender gender)
        {
            return gender == Gender.Male ?
                "John Doe" :
                "Jane Doe";
        }
    }
}
