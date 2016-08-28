using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class PlayerStateMachine : BehaviorStateMachine
    {
        public override void Initialize()
        {
            AddState<IdleState>("idle")
                .Trigger("run").When(LeftOrRightKeyDown);

            AddState<RunState>("run")
                .Trigger("idle").When(LeftAndRightKeyUp);

            Start("idle");
        }

        private bool LeftAndRightKeyUp(Behavior arg)
        {
            return Input["left"].ButtonControl.IsUp() &&
                Input["right"].ButtonControl.IsUp();
        }

        private bool LeftOrRightKeyDown(Behavior arg)
        {
            return Input["left"].ButtonControl.IsDown() ||
                Input["right"].ButtonControl.IsDown();
        }
    }
}
