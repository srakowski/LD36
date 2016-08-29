using Coldsteel;
using LD36.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class RestartState : Behavior
    {
        public override void Initialize()
        {
            State.Start<GameplayState>();
        }
    }
}
