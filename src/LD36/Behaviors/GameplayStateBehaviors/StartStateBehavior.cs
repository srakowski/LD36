using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    class StartStateBehavior : Behavior
    {
        public override void Initialize()
        {
            Terminal.Write("=== 80's IT Management Simulator ===");
            Terminal.Write("Created for Ludum Dare 36");
            Terminal.Write("By Shawn Rakowski");
            Terminal.Write("");
            Terminal.Write("Press [1] to start...");
        }
    }
}
