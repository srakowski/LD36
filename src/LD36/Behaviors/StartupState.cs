using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class StartupState : Behavior
    {
        private GameObject text;

        public override void Initialize()
        {
            text = AddGameObject()
                .Set.Position(30, 30)
                .Set.Layer("hud")
                .Add.TextRenderer("terminal", "Mine Sweepin' Miner Deluxe");

            text.AddGameObject()
                .Set.Position(0, 58)
                .Set.Layer("hud")
                .Add.TextRenderer("hud", "Created for LDJAM 36 by Shawn Rakowski\n\n" +
                "A long time ago an ancient technology was buried in the land beneath your \n" +
                "feet. To keep it safe, a number of explosive mines were buried with it. \n" +
                "Fortunately, the mines emit a radioactive frequency strong enough to tell \n" +
                "you if one or more are within one dig away from you. Unfortunately, so does \n" +
                "the ancient technology. However, the ancient technology emits a stronger frequency \n" +
                "which will look more mines are nearer to you than is possible. Using your vast \n" +
                "intelligence and logical reasoning skills you should be able to tell it apart from \n" +
                "the mines. Find the ancient technology and glory awaits!\n\n\n" +
                "You control the dude over here ------------------------------------------>\n\n\n" +
                "WASD or Arrows, digging happens automatically when you move towards a cell so be careful!\n\n" +
                "Press [space] to start...");

        }

        public override void Dispose()
        {
            text.Kill(true);
        }
    }
}
