using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    /// <summary>
    /// Strategic allocation of funds. Learn about broad initiatives they 
    /// will need to complete in the next period etc (tasks). 
    /// </summary>
    class BudgetStateBehavior : GameplayStateBehavior
    {
        public override void Initialize()
        {
            Terminal.Clear();
            Terminal.Write("BARF - Budgets ARe Friends Budgetting Tool v1.42");
            Terminal.Write("Main Menu:");
            Terminal.Write(" [1] Company Memos");
            Terminal.Write(" [2] Inventory");
            Terminal.Write(" [3] Employees");

            // Defense of the Ancient Technology
        }
    }
}
