using LD36.Models.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models.FacilityTopology
{
    class Workstation
    {
        /// <summary>
        /// The Computer in this work station.
        /// </summary>
        public Computer Computer { get; set; } = null;

        /// <summary>
        /// A telephone at this work station.
        /// </summary>
        public Telephone Telephone { get; set; } = null;

        /// <summary>
        /// Printer if any.
        /// </summary>
        public Printer Printer { get; set; } = null;

        /// <summary>
        /// The employee assigned to this workstation.
        /// </summary>
        public Employee Employee { get; set; } = null;
    }
}
