using LD36.Models.FacilityTopology;
using LD36.Models.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class Facility
    {
        private List<Workstation> _workstations = new List<Workstation>();

        /// <summary>
        /// Workstations in this facility. Computer tech + non-it employees.
        /// </summary>
        public IEnumerable<Workstation> Workstations => _workstations;

        private List<ServerRoom> _serverRooms = new List<ServerRoom>();

        /// <summary>
        /// Server Rooms in this facility.
        /// </summary>
        public IEnumerable<ServerRoom> ServerRooms => _serverRooms;

        private List<PrintStation> _printStations = new List<PrintStation>();

        /// <summary>
        /// Places where Printers are.
        /// </summary>
        public IEnumerable<PrintStation> PrintStations => _printStations;

        /// <summary>
        /// The inventory of all technology in this facility.
        /// </summary>
        public List<Technology> Inventory { get; set; } = new List<Technology>();
    }
}
