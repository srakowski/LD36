using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class RunState : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("run");
        }

        public override void Update()
        {
            if (Input["left"].ButtonControl.IsDown())
                this.Set.SpriteEffects(Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally);

            if (Input["right"].ButtonControl.IsDown())
                this.Set.SpriteEffects(Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
        }
    }
}
