using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class ITEmployee : Employee
    {
        /// <summary>
        /// Dollars per minute? second? We only care about this
        /// when the employee is one we control.
        /// </summary>
        public int PayRate { get; set; }
    }
}
