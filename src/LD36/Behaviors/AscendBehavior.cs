using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LD36.Behaviors
{
    public class AscendBehavior : Behavior
    {
        private Vector2 _vel;
        private bool stop;

        public override void Initialize()
        {
            this.Add.ParticleEmitter("ex");
            this.Add.AudioSource("explode2");
            StartCoroutine(ExplodeIntoSpace());
        }

        private IEnumerator ExplodeIntoSpace()
        {
            while (Transform.Position.Y > -200)
            {
                yield return WaitMSecs(600);
            }

            stop = true;
            ParticleEmitter.Emit(60);
            AudioSource.Play();

            var text = World.AddGameObject()
                .Set.Position(30, 30)
                .Set.Layer("hud")
                .Add.TextRenderer("terminal", "YOU WIN!");

            text.AddGameObject()
                .Set.Position(0, 58)
                .Set.Layer("hud")
                .Add.TextRenderer("hud", "Unfortunately the ancient technology isn't really that cool...\n\n" +
                "Oh well...\n\n" +
                "See you next Ludum Dare!!!!\n\n" +
                "Press [space] to try again...");
        }

        public override void Update()
        {
            if (stop)
                return;

            _vel += new Vector2(0, -0.001f) * GameTime.Delta;
            if (_vel.Y <= -1f)
                _vel.Y = -1f;

            Transform.Position += _vel * GameTime.Delta;
        }
    }
}
