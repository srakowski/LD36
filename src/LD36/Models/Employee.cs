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
    class Employee
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
    }
}
