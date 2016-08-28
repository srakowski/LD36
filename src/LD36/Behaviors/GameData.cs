using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class GameData
    {
        public Map Map { get; set; }
        public GameObject Miner { get; set; }
        public TileBehavior[,] Tiles { get; set; }
    }
}
