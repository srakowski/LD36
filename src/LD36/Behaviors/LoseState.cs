using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class LoseState : Behavior
    {
        private GameData GameData => Data as GameData;

        public override void Initialize()
        {
            GameData.Miner.Kill();
        }
    }
}
