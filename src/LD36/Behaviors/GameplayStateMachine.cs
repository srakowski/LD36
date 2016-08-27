using Coldsteel;
using LD36.Behaviors.GameplayStateBehaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class GameplayStateMachine : StateMachine
    {
        public override void Initialize()
        {
            AddState<BudgetStateBehavior>("budget")
                .Trigger("operate").When(BudgetOkayed);

            AddState<OperateStateBehavior>("operate")
                .Trigger("analysis").When(OperationPeriodEnded);

            AddState<AnalysisStateBehavior>("analysis")
                .Trigger("progress").When(AnalysisOkayed);

            AddState<ProgressStateBehavior>("progress")
                .Trigger("lose").When(Fired)
                .Trigger("win").When(PromotedToCio)
                .Trigger("budget").When(ProgressionOkayed);

            AddState<LoseStateBehavior>("lose");

            AddState<WinStateBehavior>("win");

            Start("budget");
        }

        private bool BudgetOkayed(Behavior gameplayState)
        {
            return true;
        }

        private bool OperationPeriodEnded(Behavior gameplayState)
        {
            var operateState = gameplayState as OperateStateBehavior;
            return operateState.HasPeriodEnded;
        }

        private bool AnalysisOkayed(Behavior gameplayState)
        {
            return true;
        }

        private bool PromotedToCio(Behavior gameplayState)
        {
            return true;
        }

        private bool Fired(Behavior gameplayState)
        {
            return true;
        }

        private bool ProgressionOkayed(Behavior gameplayState)
        {
            return true;
        }
    }
}
