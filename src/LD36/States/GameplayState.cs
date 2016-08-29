using Coldsteel;
using LD36.Behaviors;
using LD36.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.States
{
    class GameplayState : GameState
    {
        public override void Preload()
        {
            Load.Image("mined");
            Load.Image("ground");
            Load.Image("topground");
            Load.SpriteSheet("miner", 50, 50);
            Load.Image("tile");
            Load.Image("dug");
            Load.Image("ex");
            Load.SpriteFont("terminal");
            Load.SpriteFont("hud");
            Load.SpriteSheet("tilesheet", 120, 120);
            Load.SpriteSheet("numsheet", 48, 48);
            Load.Image("mine");
            Load.Image("atech");
            Load.Image("blood");
            Load.SoundEffect("explode");
            Load.SoundEffect("explode2");
            Load.SoundEffect("dig");
            Load.SoundEffect("minenum");
            Load.SoundEffect("getdisk");
            Load.LoadAndPlaySong("song");
        }

        public override void Create()
        {
            Stage.BackgroundColor = GameColors.Background;

            Layers.Add("hud", 100).StickToCamera = true;

            Layers.Add("blood", 90).BlendState = BlendState.NonPremultiplied;

            World.Gravity = new Vector2(0f, 9.86f);

            World.AddGameObject()
                .Add.Component(new FlowStateMachine());

            Layers.Add("reader", -1);
            Layers.Add("dug", -2);

            var map = new Map();
            GameObject at = null;
            var tiles = new TileBehavior[map.NumCols + 2, map.NumRows + 3];
            var field = World.AddGameObject();
            for (var x = 0; x < map.NumCols; x++)
                for (var y = 0; y < map.NumRows; y++)
                {
                    var tileModel = map.GetTile(x, y);
                    var tileBehav = new TileBehavior(tileModel, null);
                    var tileGO = field.AddGameObject()
                        .Set.Position(96 + (x * 96), 96 + (y * 96))
                        .Add.SpriteSheetRenderer("tilesheet")
                        .Add.Animation("ltbr", 0)
                        .Add.Animation("lbr", 1)
                        .Add.Animation("lb", 2)
                        .Add.Animation("br", 3)
                        .Add.Animation("lr", 4)
                        .Add.Animation("tb", 5)
                        .Add.Animation("ltb", 6)
                        .Add.Animation("tbr", 7)
                        .Add.Animation("ltr", 8)
                        .Add.Animation("lt", 9)
                        .Add.Animation("tr", 10)
                        .Add.Animation("l", 11)
                        .Add.Animation("r", 12)
                        .Add.Animation("t", 13)
                        .Add.Animation("b", 14)
                        .Add.Animation("", 15)
                        .Add.Animation("sltbr", 16)                        
                        .Add.Component(tileBehav);
                    tiles[x + 1, y + 2] = tileBehav;
                    tileGO.AddGameObject()
                        .Set.Layer("dug")
                        .Add.SpriteRenderer("dug");
                    if (tileModel.Type == TileType.Dirt && tileModel.AdjMineCount != 0)
                    {
                        tileGO.AddGameObject()
                            .Set.Layer("reader")
                            .Add.SpriteSheetRenderer("numsheet")
                            .Add.Animation("1", 0)
                            .Add.Animation("2", 1)
                            .Add.Animation("3", 2)
                            .Add.Animation("4", 3)
                            .Add.Animation("5", 4)
                            .Add.Animation("6", 5)
                            .Add.Animation("7", 6)
                            .Add.Animation("8", 7)
                            .Animations.Play(tileModel.AdjMineCount.ToString());
                    }
                    else if (tileModel.Type == TileType.Mine)
                    {
                        tileGO.AddGameObject()
                            .Set.Layer("reader")
                            .Add.SpriteRenderer("mine");
                    }
                    else if (tileModel.Type == TileType.AncientTechnology)
                    {
                        at = tileGO.AddGameObject()
                            .Set.Layer("reader")
                            .Add.SpriteRenderer("atech");
                    }
                }

            var miner = World.AddGameObject()
                .Set.Position((map.NumCols / 2f) * 96f, 24f)
                .Add.SpriteSheetRenderer("miner")
                .Add.Animation("idle", new int[] { 0, 1, 2, 3 }, 300)
                .Add.Animation("run", new int[] { 4, 5, 6, 7 }, 200)
                .Add.AudioSource("dig")
                .Add.Component(new PlayerStateMachine());

            var follow = new FollowBehavior(miner);
            Camera.Add.Component(follow);

            Data = new GameData()
            {
                Map = map,
                Tiles = tiles,
                Miner = miner, 
                AncientTech = at,
                Follow = follow,
            };
        }
    }
}
