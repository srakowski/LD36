using Coldsteel;
using Coldsteel.Rendering;
using LD36.Behaviors;
using LD36.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.States
{
    class GameplayState : GameState
    {
        public override void Preload()
        {
            Load.SpriteFont("terminal");
        }

        public override void Create()
        {
            Stage.BackgroundColor = Color.Black;

            var model = GameplayModel.Create("Shawn Rakowski", Gender.Male);
            Data = model;

            World.AddGameObject("gameStateMachine")
                .Add.Component(new GameplayStateMachine());

            var terminal = World.AddGameObject("terminal")
                .Set.Position(10, 10);

            var numRows = 36;
            var lines = new TextRenderer[numRows];
            for (var r = 0; r < numRows; r++)
            {
                var line = terminal.AddGameObject()
                    .Set.Position(0, r * 20)
                    .Add.TextRenderer("terminal", "", GameColors.Terminal);
                lines[r] = line.Renderer as TextRenderer;
            }
            terminal.Add.Component(new DisplayTerminalBehavior(lines));
        }
    }
}
