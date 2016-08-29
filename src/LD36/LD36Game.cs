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
            Input.AddButtonControl("left")
                .Keyboard(Keys.A, Keys.Left);

            Input.AddButtonControl("right")
                .Keyboard(Keys.D, Keys.Right);

            Input.AddButtonControl("up")
                .Keyboard(Keys.W, Keys.Up);

            Input.AddButtonControl("down")
                .Keyboard(Keys.S, Keys.Down);

            Input.AddButtonControl("continue")
                .Keyboard(Keys.Space, Keys.Enter);

            State.Start<GameplayState>();
        }
    }
}
