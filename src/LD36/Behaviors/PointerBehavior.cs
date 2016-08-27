using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class PointerBehavior : Behavior
    {
        public override void Update()
        {
            Transform.Position = Input.MousePosition;
        }
    }
}
