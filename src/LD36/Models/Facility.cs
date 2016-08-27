using LD36.Models.FacilityTopology;
using LD36.Models.Technologies;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class Facility
    {
        public string Name { get; set; }

        private List<Workstation> _workstations = new List<Workstation>();

        /// <summary>
        /// Workstations in this facility. Computer tech + non-it employees.
        /// </summary>
        public IEnumerable<Workstation> Workstations => _workstations;


        private List<Office> _offices = new List<Office>();

        /// <summary>
        /// Just bigger workstations, mostly for viewing.
        /// </summary>
        public IEnumerable<Office> Offices => _offices;


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
        /// Create a facility with these properties.
        /// </summary>
        /// <param name="numWorkStations"></param>
        /// <param name="numOffices"></param>
        /// <param name="numPrintStations"></param>
        /// <param name="numServerRooms"></param>
        /// <returns></returns>
        public static Facility Create(string name,
            int numWorkStations, int numOffices, 
            int numPrintStations, int numServerRooms)
        {
            var facility = new Facility();

            facility.Name = name;

            for (var i = 0; i < numWorkStations; i++)
                facility._workstations.Add(new Workstation());

            for (var i = 0; i < numOffices; i++)
                facility._offices.Add(new Office());

            for (var i = 0; i < numPrintStations; i++)
                facility._printStations.Add(new PrintStation());

            for (var i = 0; i < numServerRooms; i++)
                facility._serverRooms.Add(new ServerRoom());

            return facility;
        }
    }
}
