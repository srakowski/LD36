using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class Company
    {
        public string Name { get; set; }

        private List<Facility> _facilities = new List<Facility>();

        /// <summary>
        /// The facilities this company owns. Plays into number of employees
        /// ultimately tickets coming in, size and scope of issues.
        /// </summary>
        public IEnumerable<Facility> Facilities => _facilities;


        private List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// All company employees, including IT employees.
        /// </summary>
        public IEnumerable<Employee> Employees => _employees;


        private List<Technology> _inventory => new List<Technology>();

        /// <summary>
        /// This company's technology inventory.
        /// </summary>
        public IEnumerable<Technology> Inventory => _inventory;

        private Company() { }

        private const int NumInitialITEmployees = 2;
        private const int NumInitialGeneralEmployees = 23;
        private const int NumInitialWorkstations = 36;
        private const int NumInitialOffices = 36;
        private const int NumInitialPrintStations = 36;
        private const int NumInitialServerRooms = 36;

        /// <summary>
        /// Create a company/
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        public static Company Create(Random rand, string playerName, Gender playerGender)
        {
            var company = new Company();

            company.Name = NameGenerator.GenerateCompanyName(rand);
            GenerateInitialFacility(rand, company);
            GenerateInitialEmployees(rand, company, playerName, playerGender);
            GenerateInitialInventory(rand, company);
            

            return company;
        }

        private static void GenerateInitialFacility(Random rand, Company company)
        {
            company._facilities.Add(Facility.Create(
                $"{company.Name}-HQ",
                NumInitialWorkstations,
                NumInitialOffices,
                NumInitialPrintStations,
                NumInitialServerRooms
                ));
        }

        private static void GenerateInitialEmployees(Random rand, Company company,
            string playerName, Gender playerGender)
        {
            company._employees.Add(Employee.GeneratePlayerEmployee(rand, playerName, playerGender));

            company._employees.Add(Employee.GenerateCeoEmployee(rand));

            for (int i = 0; i < NumInitialITEmployees; i++)
                company._employees.Add(Employee.GenerateITEmployee(rand));

            for (int i = 0; i < NumInitialGeneralEmployees; i++)
                company._employees.Add(Employee.GenerateGeneralEmployee(rand));
        }

        private static void GenerateInitialInventory(Random rand, Company company)
        {

        }
    }
}
