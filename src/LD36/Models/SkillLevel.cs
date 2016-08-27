using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class SkillLevel
    {
        /// <summary>
        /// Usage skill, general skill at using the tech.
        /// </summary>
        public int Usage { get; set; }

        /// <summary>
        /// Troubleshooting, general skill at troubleshoting this tech.
        /// </summary>
        public int Troubleshooting { get; set; }
    }
}
