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
            AddState<StartStateBehavior>("start")
                .Trigger("story").When(Op1Pressed);

            AddState<BackStoryStateBehavior>("story")
                .Trigger("instructions").When(Op1Pressed);

            AddState<InstructionsStateBehavior>("instructions")
                .Trigger("budget").When(Op1Pressed);

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

            Start("start");
        }

        private bool Op1Pressed(Behavior gameplayState) => Input["op1"].ButtonControl.WasDown();

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
