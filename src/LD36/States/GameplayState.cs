using Coldsteel;
using LD36.Behaviors;
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
        }

        public override void Create()
        {
            Stage.BackgroundColor = Color.CornflowerBlue;
            World.AddGameObject("GameManager")
                .Add.Component(new GameplayStateMachine());
        }
    }
}
