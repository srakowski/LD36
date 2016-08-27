using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Models
{
    /// <summary>
    /// These will be assigned to employees to accomplish. They have TIME and COST
    /// associated with them. Some may be more than a single person job. They also
    /// have a priority assigned to them? <- should this be set by user?
    /// 
    /// TODO: assigned employee should affect variables of the job. For instance
    /// a person good with printers is probably going to take less time to perform
    /// a task. these are not fixed values!
    /// </summary>
    class Task
    {

        /// <summary>
        /// Fluff, really just for ambiance/simluation feel.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Fluff, really just for ambiance/simluation feel.
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Is this a support ticket or a corporate initiative?
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// Feeds into analysis, not pleasing  the CEO can be bad, unless helps company
        /// </summary>
        public int PriorityToCeo { get; set; }

        /// <summary>
        /// What is really important to the company, but the CEO decides your fate not the 
        /// abstraction of the company, though, a well run company makes for a happy CEO. DESCISIONS!
        /// </summary>
        public int PriorityToCompany { get; set; }

        /// <summary>
        /// Time is a resource during the operation period. This is how much time is required
        /// to complete the task total. Employee time this is.
        /// </summary>
        public int TimeCost { get; set; }

        /// <summary>
        /// This is how much money this costs. May be calculated based on employee rate * time per employee needed
        /// plus fixed cost things like hardware/software cost.
        /// </summary>
        public int BudgetCost { get; set; }

        /// <summary>
        /// How many employees I must use to complete the task.
        /// </summary>
        public int NumberOfPersonJob { get; set; }
    }
}
