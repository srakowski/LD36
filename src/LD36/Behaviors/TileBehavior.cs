using Coldsteel;
using LD36.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class TileBehavior : Behavior
    {
        private Tile _tile;
        private GameObject _hit;

        public TileBehavior(Tile tile, GameObject hit)
        {
            _tile = tile;
            _tile.OnMined = UpdateAnimation;
            _tile.OnAdjMined = UpdateAnimation;
            _hit = hit;
        }

        public override void Initialize()
        {
            Animations.Play(this._tile.Pos.Y == 0 ? "sltbr" : "ltbr");
        }

        public bool IsMined => _tile.IsMined;

        public Rectangle BoundingBox => new Rectangle((int)this.Transform.Position.X - 48, (int)this.Transform.Position.Y - 48, 96, 96);

        internal void Mine()
        {
            _tile.Mine();
            _tile.UpdateAdjTiles();
            _hit?.Kill();
            _hit = null;
        }

        private void UpdateAnimation()
        {
            var anim = "";

            if (!this.IsMined && this._tile.Pos.Y == 0)
                anim += "s";

            if (_tile.HasAdjL)
                anim += "l";

            if (_tile.HasAdjT)
                anim += "t";

            if (_tile.HasAdjB)
                anim += "b";

            if (_tile.HasAdjR)
                anim += "r";

            Animations.Play(anim);
        }
    }
}
