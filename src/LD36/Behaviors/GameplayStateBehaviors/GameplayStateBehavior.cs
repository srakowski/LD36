using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    abstract class GameplayStateBehavior : Behavior
    {
        protected GameplayModel GameplayModel => Data as GameplayModel;
    }
}
