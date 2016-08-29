using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD36.Models
{
    class Map
    {
        private Random _rand = new Random();

        private Point _ancientTechLocation;

        private List<Tile> _mines = new List<Tile>();

        private const int MAP_COLS = 24;
        public int NumCols => MAP_COLS;

        private const int MAP_ROWS = 24;
        public int NumRows => MAP_ROWS;

        public bool AnyMinesTripped => _mines.Any(m => m.IsMined);

        public Tile AncientTechnology => GetTile(_ancientTechLocation);

        private const int NUM_MINES = ((MAP_COLS * MAP_ROWS) / 7);

        private Tile[,] _map = new Tile[MAP_COLS, MAP_ROWS];

        public Map()
        {
            for (int x = 0; x < MAP_COLS; x++)
                for (int y = 0; y < MAP_ROWS; y++)
                {
                    var adjPoints = new List<Point>();
                    if (x > 0 && y > 0) adjPoints.Add(new Point(x - 1, y - 1));
                    if (y > 0) adjPoints.Add(new Point(x, y - 1));
                    if (x < MAP_COLS - 1  && y > 0) adjPoints.Add(new Point(x + 1, y - 1));
                    if (x > 0) adjPoints.Add(new Point(x - 1, y));
                    if (x < MAP_COLS - 1) adjPoints.Add(new Point(x + 1, y));
                    if (x > 0 && y < MAP_ROWS - 1) adjPoints.Add(new Point(x - 1, y + 1));
                    if (y < MAP_ROWS - 1) adjPoints.Add(new Point(x, y + 1));
                    if (x < MAP_COLS - 1 && y < MAP_ROWS - 1) adjPoints.Add(new Point(x + 1, y + 1));
                    _map[x, y] = new Tile(this, new Point(x, y), _rand.Next(1, 3), adjPoints);
                }

            PlaceAncientTechnology();
            PlaceMines();
        }

        public Tile GetTile(Point p) => this.GetTile(p.X, p.Y);

        internal Tile GetTile(int x, int y)
        {
            return _map[x, y];
        }

        private void PlaceAncientTechnology()
        {
            var col = _rand.Next(MAP_COLS);
            var row = _rand.Next(MAP_ROWS - (MAP_ROWS / 2), MAP_ROWS);
            _map[col, row].Type = TileType.AncientTechnology;
            _ancientTechLocation = new Point(col, row);
        }

        private void PlaceMines()
        {
            for (var n = 0; n < NUM_MINES; n++)
            {
                var candidateTile = _map[_rand.Next(MAP_COLS), _rand.Next(1, MAP_ROWS)];
                while (candidateTile.Type != TileType.Dirt || candidateTile.IsAdjToAncTech)
                    candidateTile = _map[_rand.Next(MAP_COLS), _rand.Next(1, MAP_ROWS)];
                candidateTile.Type = TileType.Mine;
                _mines.Add(candidateTile);
            }
        }
    }
}