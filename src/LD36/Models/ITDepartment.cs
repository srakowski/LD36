using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    class ITDepartment
    {
        private int _moneyInBudget;

        /// <summary>
        /// Gets the remaining money in the budget.
        /// </summary>
        public int MoneyInBudget => _moneyInBudget;


        private List<ITEmployee> _employees = new List<ITEmployee>();

        /// <summary>
        /// Gets the employees of the IT Dept.
        /// </summary>
        public IEnumerable<ITEmployee> Employees => _employees;


        private List<Task> _tasks = new List<Task>();

        /// <summary>
        /// Gets the IT departments task list.
        /// </summary>
        public IEnumerable<Task> Tasks => _tasks;
    }
}
