using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class EmployeeSkillLevels
    {
        /// <summary>
        /// How good is this employee with software?
        /// </summary>
        public SkillLevel SoftwareUse { get; set; }

        /// <summary>
        /// How good is this employee with computer hardware?
        /// </summary>
        public SkillLevel Hardware { get; set; }

        /// <summary>
        /// How good is this employee with telephones?
        /// </summary>
        public SkillLevel Telephony { get; set; }

        /// <summary>
        /// How good is this employee with printers?
        /// </summary>
        public SkillLevel Printer { get; set; }

        /// <summary>
        /// How good is this employee with networking?
        /// </summary>
        public SkillLevel Networking { get; set; }
    }
}
