using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    class InstructionsStateBehavior : GameplayStateBehavior
    {
        public override void Initialize()
        {
            Terminal.Clear();
            Terminal.Write("Your first act as manager will be to create a budget for the next period. " + 
                $"Create your budget proposal using {GameplayModel.Company.Name}'s budgetting tool. When you are done, submit it to " +
                $"{GameplayModel.Company.Ceo.Name} for review. {GameplayModel.Company.Ceo.HeOrShe} will consider your budget proposal, and " +
                $"send you a memo with the amount {GameplayModel.Company.Ceo.HeOrShe.ToLower()} is willing to grant you.");
            Terminal.Write("");
            Terminal.Write("There are a number of things you'll need to keep in mind while creating your budget. Review company " +
                "memos for any initiatives that may require new technology purchases or require you to hire additional staff. " +
                "Keep an eye on the age of the company's inventory. Failures do happen as technology ages, and you may want to " +
                "regularly upgrade systems to reduce tickets and prevent costly repairs that drain your budget." +
                "Employee payroll is hard to balance. Hire too many and it will eat at your budget. Hire too few and you may " +
                "not be able to keep pace with the company's support tickets. Training employees is also important. One well " +
                "trained employee may do the work of two untrained employees, but training costs money. Sometimes it is worth it, but " +
                "other times the money is better spent elsewhere.");
            Terminal.Write("");
            Terminal.Write($"Do your best. {GameplayModel.Company.Ceo.Name} won't expect the world from you your first few times, but " +
                $"you'll need to get good at this if you want to keep your job. Do well and you may surprise {GameplayModel.Company.Ceo.HimOrHer}. Good luck!");
            Terminal.Write("");
            Terminal.Write("Press [1] to start your budget...");
        }
    }
}
