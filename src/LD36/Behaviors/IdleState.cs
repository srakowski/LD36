using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class IdleState : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("idle");
        }
    }
}
