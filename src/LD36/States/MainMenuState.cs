using Coldsteel;
using LD36.Behaviors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.States
{
    /// <summary>
    /// Display Title, Instructions?, Play Button
    /// </summary>
    class MainMenuState : GameState
    {
        public override void Preload()
        {
            Load.Image("pointer");
            Load.SpriteFont("title");
            Load.SpriteFont("ui");
        }

        public override void Create()
        {
            Stage.BackgroundColor = Color.Beige;

            World.AddGameObject()
                .Set.Position(100, 100)
                .Add.TextRenderer("title", "IT Management Simulator '84", Color.Black);

            World.AddGameObject()
                .Set.Position(300, 280)
                .Add.TextRenderer("ui", "New Game", Color.Black);

            World.AddGameObject()
                .Set.Position(300, 350)
                .Add.TextRenderer("ui", "Exit", Color.Black);

            World.AddGameObject()
                .Add.SpriteRenderer("pointer")
                .Add.Component(new PointerBehavior());
        }
    }
}
