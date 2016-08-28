using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    class BackStoryStateBehavior : GameplayStateBehavior
    {
        public override void Initialize()
        {
            Terminal.Clear();
            Terminal.Write("The year is 1980 and " + 
                $"you have just accepted a job as Manager of Information Technology for {GameplayModel.Company.Name}. As " +
                "Manager of IT it is your responsibility to keep the company's technology is running smoothly. You are " +
                "also responsible for purchasing and implementing new technologies, managing your IT team, and, yes, " +
                "budgeting."
                );
            Terminal.Write("");
            Terminal.Write($"{GameplayModel.Company.Name}'s CEO, {GameplayModel.Company.Ceo.Name}, was not impressed with the " +
                $"last manager and fired him. {GameplayModel.Company.Ceo.HeOrShe} now has an unfavorable opinion of IT people in " +
                $"general, and will fire you if {GameplayModel.Company.Ceo.HeOrShe.ToLower()} feels you aren't living up to your resume, but " +
                $"if you do well and gain {GameplayModel.Company.Ceo.HisOrHer.ToLower()} trust you may one day be promoted to CIO.");
            Terminal.Write("");
            Terminal.Write("Press [1] to continue...");
        }
    }
}
