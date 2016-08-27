using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    /// <summary>
    /// As much as I hate this, the employee is a resource to assign things to
    /// but they have a name damnit! Not all employees are created equal. Some are better at
    /// other things. Tasks need to play off strengths/weaknesses of employees. 
    /// Do we send Joe to go fix a printer if he has no experience with them? Part of management
    /// is to make sure your employees are fucking awesome at things. 
    /// </summary>
    abstract class Employee
    {
        /// <summary>
        /// This employees name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// On some scale, how equiped is the employee to deal with
        /// certain kind of IT issues... affects pay rate?
        /// </summary>
        public EmployeeSkillLevels SkillLevels { get; set; }

        /// <summary>
        /// Only really used for visuals/names.
        /// </summary>
        public Gender Gender { get; private set; }

        public static Employee GeneratePlayerEmployee(Random rand, string name, Gender gender)
        {
            var employee = new PlayerEmployee();
            employee.Name = name;
            employee.Gender = gender;
            return employee;
        }

        public static Employee GenerateCeoEmployee(Random rand)
        {
            var employee = new CeoEmployee();
            return SetAttributes(rand, employee);
        }

        public static Employee GenerateITEmployee(Random rand)
        {
            var employee = new ITEmployee();
            return SetAttributes(rand, employee);
        }

        public static Employee GenerateGeneralEmployee(Random rand)
        {
            var employee = new GeneralEmployee();
            return SetAttributes(rand, employee);
        }

        private static Employee SetAttributes(Random rand, Employee employee)
        {
            employee.Gender = rand.Next(100) < 50 ? Gender.Male : Gender.Female;
            employee.Name = NameGenerator.GeneratePersonName(rand, employee.Gender);
            return employee;
        }
    }
}
