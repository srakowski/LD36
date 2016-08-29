using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class PlayState : Behavior
    {
        public override void Initialize()
        {
            var gd = Data as GameData;
            gd.Miner.Add.Component(new PlayerBehavior(gd.Map.NumCols / 2, 1, gd.Tiles));
        }
    }
}
