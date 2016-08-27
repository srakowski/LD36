using Coldsteel;
using LD36.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36
{
    class LD36Game : Game
    {
        public override void Initialize()
        {
            State.Start<MainMenuState>();
        }
    }
}
