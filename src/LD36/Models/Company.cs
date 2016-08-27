using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class Company
    {
        private List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// All company employees, including IT employees.
        /// </summary>
        public IEnumerable<Employee> Employees => _employees;

        private List<Facility> _facilities = new List<Facility>();

        /// <summary>
        /// The facilities this company owns. Plays into number of employees
        /// ultimately tickets coming in, size and scope of issues.
        /// </summary>
        public IEnumerable<Facility> Facilities => _facilities;
    }
}
