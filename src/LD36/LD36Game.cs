using Coldsteel;
using LD36.States;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36
{
    class LD36Game : Game
    {
        public override void Initialize()
        {
            Input.AddButtonControl("op1")
                .Keyboard(Keys.D1);

            State.Start<GameplayState>();
        }
    }
}
