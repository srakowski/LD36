using Coldsteel;
using LD36.Behaviors;
using LD36.Models;
using LD36.ViewModels;
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

            var model = GameplayModel.Create("Shawn Rakowski", Gender.Male);
            Data = model;

            World.AddGameObject("gameStateMachine")
                .Add.Component(new GameplayStateMachine());

            World.AddGameObject("facilityView")
                .Add.Component(new FacilityViewBehavior(new FacilityViewModel(model)));

            Layers.Add("hud", 1);
            World.AddGameObject("hudView")
                .Add.Component(new HudViewBehavior(new HudViewModel(model)));
        }
    }
}
