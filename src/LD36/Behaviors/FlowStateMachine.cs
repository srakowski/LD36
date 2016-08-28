using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class FlowStateMachine : BehaviorStateMachine
    {
        private GameData GameData => Data as GameData;

        public override void Initialize()
        {
            AddState<StartupState>("start")
                .Trigger("play").When(ContinuePressed);

            AddState<PlayState>("play")
                .Trigger("lose").When(MinesMined)
                .Trigger("win").When(AncientTechnologyMined);

            AddState<LoseState>("lose")
                .Trigger("restart").When(ContinuePressed);

            AddState<WinState>("win")
                .Trigger("restart").When(ContinuePressed);

            AddState<RestartState>("restart");

            Start("start");
        }

        private bool ContinuePressed(Behavior state) => Input["continue"].ButtonControl.WasDown();

        private bool MinesMined(Behavior arg)
        {
            return GameData.Map.AnyMinesTripped;
        }

        private bool AncientTechnologyMined(Behavior arg)
        {
            return GameData.Map.AncientTechnology.IsMined;
        }
    }
}
