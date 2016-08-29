using Coldsteel;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class LoseState : Behavior
    {
        private GameData GameData => Data as GameData;
        private GameObject text;

        public override void Initialize()
        {
            MediaPlayer.Stop();
            Add.AudioSource("explode");
            AudioSource.Play();            
            var d = World.AddGameObject()
                .Set.Position(GameData.Miner.Transform.Position)
                .Set.Layer("blood")
                .Add.ParticleEmitter("blood");
            GameData.Follow.Subject = d;
            d.ParticleEmitter.Emit(100);
            GameData.Miner.Kill(true);

            text = AddGameObject()
                .Set.Position(30, 30)
                .Set.Layer("hud")
                .Add.TextRenderer("terminal", "BOOM! You dug up a mine and died.");

            text.AddGameObject()
                .Set.Position(0, 58)
                .Set.Layer("hud")
                .Add.TextRenderer("hud", "That's okay, I was never good at mine sweeper either...\n\n" +
                "Press [space] to try again...");

        }

        public override void Dispose()
        {
            text.Kill(true);
        }
    }
}
