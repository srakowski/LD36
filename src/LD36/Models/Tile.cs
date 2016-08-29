using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Linq;

namespace LD36.Models
{
    class Tile
    {
        private List<Point> _adjPoints;

        private Map _map;

        public TileType Type { get; set; } = TileType.Dirt;

        private IEnumerable<Tile> AdjTiles => _adjPoints.Select(p => _map.GetTile(p));

        public bool IsAdjToAncTech => AdjTiles.Any(t => t.Type == TileType.AncientTechnology);

        private int _readingOffset = 0;

        public int AdjMineCount
        {
            get
            {
                var count = AdjTiles.Count(t => t.Type == TileType.Mine || t.Type == TileType.AncientTechnology);
                if (IsAdjToAncTech)
                    count += _readingOffset;
                count = MathHelper.Clamp(count, 0, 8);
                return count;
            }
        }

        internal void UpdateAdjTiles()
        {
            foreach (var tile in AdjTiles)
                if (tile.IsMined)
                    tile.OnAdjMined?.Invoke();
        }

        public bool IsMined { get; private set; } = false;

        public bool IsPickedUp { get; set; } = false;

        public Action OnMined { get; internal set; }

        public Action OnAdjMined { get; set; }

        public void Mine(bool clear = false)
        {
            if (this.IsMined)
                return;

            this.IsMined = true;
            OnMined?.Invoke();

            if (!clear)
                return;

            if (this.Type == TileType.Mine || this.Type == TileType.AncientTechnology)
                return;

            if (this.AdjMineCount != 0)
                return;

            foreach (var tile in AdjTiles)
                tile.Mine(false);
        }

        public Point Pos { get; set; }

        public bool HasAdjL => AdjTiles.Any(t => !t.IsMined && t.Pos == (Pos + new Point(-1, 0))) && Pos.X != 0;

        public bool HasAdjR => AdjTiles.Any(t => !t.IsMined && t.Pos == (Pos + new Point(1, 0))) && Pos.X != _map.NumCols - 1;

        public bool HasAdjB => AdjTiles.Any(t => !t.IsMined && t.Pos == (Pos + new Point(0, 1))) && Pos.Y != _map.NumRows - 1;

        public bool HasAdjT => AdjTiles.Any(t => !t.IsMined && t.Pos == (Pos + new Point(0, -1))) && Pos.Y != 0;

        public Tile(Map map, Point pos, int readingOffset, List<Point> adjPoints)
        {
            this._map = map;
            this.Pos = pos;
            this._readingOffset = readingOffset;
            this._adjPoints = adjPoints;
        }
    }
}
