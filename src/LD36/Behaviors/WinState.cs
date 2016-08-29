using Coldsteel;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class WinState : Behavior
    {
        private GameData GameData => Data as GameData;

        public override void Initialize()
        {
            GameData.Miner.Kill();
            MediaPlayer.Stop();
            GameData.Follow.Subject = GameData.AncientTech;
            GameData.AncientTech
                .Add.Component(new AscendBehavior());
        }
    }
}
