using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class PlayerBehavior : Behavior
    {
        private TileBehavior[,] _tiles;

        private Rectangle BoundingBox => new Rectangle((int)this.Transform.Position.X, (int)this.Transform.Position.Y, 24, 24);

        private int _posX;
        private int _posY;

        public PlayerBehavior(int posX, int posY, TileBehavior[,] tiles)
        {
            this._posX = posX;
            this._posY = posY;
            this._tiles = tiles;
        }

        public override void Update()
        {
            this._posX = (int)((Math.Ceiling(Transform.Position.X) + 48) - (Math.Ceiling(Transform.Position.X + 48) % 96)) / 96;

            if (Input["left"].ButtonControl.IsDown() && _posX > 0)
            {
                this.Transform.Position += new Vector2(-0.3f, 0) * GameTime.Delta;
                this.Animations.Play("run");
                this.Set.SpriteEffects(Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally);

                var tile = this._tiles[_posX - 1, _posY];
                if (!tile?.IsMined ?? false)
                {
                    if (Vector2.Distance(tile.GameObject.Transform.Position, this.Transform.Position) < 68)
                    {
                        AudioSource.Play();
                        tile.Mine();
                    }
                }
            }

            if (Input["right"].ButtonControl.IsDown() && _posX < (Data as GameData).Map.NumCols + 1)
            {
                this.Transform.Position += new Vector2(0.3f, 0) * GameTime.Delta;
                this.Animations.Play("run");
                this.Set.SpriteEffects(Microsoft.Xna.Framework.Graphics.SpriteEffects.None);

                var tile = this._tiles[_posX + 1, _posY];
                if (!tile?.IsMined ?? false)
                {
                    if (Vector2.Distance(tile.GameObject.Transform.Position, this.Transform.Position) < 68)
                    {
                        AudioSource.Play();
                        tile.Mine();
                    }
                }
                //else
                //{
                //    this.Transform.Position += new Vector2(96, 0);
                //    this._posX += 1;
                //}
            }

            if (Input["up"].ButtonControl.WasUp() && _posY > 1)
            {
                var tile = this._tiles[_posX, _posY - 1];
                if (!tile?.IsMined ?? false)
                {
                    AudioSource.Play();
                    tile.Mine();
                }
                else
                {
                    this.Transform.Position += new Vector2(0, -96);
                    this._posY -= 1;
                }
            }

            if (Input["down"].ButtonControl.WasUp() && _posY < (Data as GameData).Map.NumRows + 1)
            {
                var tile = this._tiles[_posX, _posY + 1];
                if (tile != null)
                {
                    if (!tile?.IsMined ?? false)
                    {
                        AudioSource.Play();
                        tile.Mine();
                    }
                    else
                    {
                        this.Transform.Position += new Vector2(0, 96);
                        this._posY += 1;
                    }
                }
            }

            var map = (Data as GameData).Map;
            var terl = this._tiles[_posX, _posY];
            if (terl?.IsAncientTech ?? false)
            {
                Add.AudioSource("getdisk");
                AudioSource.Play();
                map.AncientTechnology.IsPickedUp = true;
            }
        }
    }
}
