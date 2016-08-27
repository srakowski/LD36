using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class PointerBehavior : Behavior
    {
        public override void Update()
        {
            Transform.Position = Input.MousePosition +
                new Vector2(8, 8) -
                new Vector2(((int)Input.MousePosition.X % 16), ((int)Input.MousePosition.Y % 20));
        }
    }
}
