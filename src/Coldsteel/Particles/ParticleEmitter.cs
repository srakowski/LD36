﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Coldsteel.Extensions;

namespace Coldsteel.Particles
{
    public class ParticleEmitter : GameObjectComponent
    {
        public Texture2D Image { get; set; }

        private Random _rand = new Random();

        public ParticleEmitter(Texture2D image)
        {
            this.Image = image;
        }

        public void Emit(int count)
        {
            Particles.AddParticles(ParticleGenerator(count));
        }

        private IEnumerable<Particle> ParticleGenerator(int count)
        {
            for (var i = 0; i < count; i++)
                yield return new Particle()
                {
                    Position = Transform.Position,
                    LayerKey = Layer.Key,
                    Image = Image,
                    Origin = Image.GetMidpoint(),
                    Color = new Color(_rand.Next(100, 255), _rand.Next(100, 255), _rand.Next(100, 255), _rand.Next(100, 255)),
                    Rotation = 2f,
                    Scale = 2f,
                    Ttl = 300,
                    Velocity = new Vector2(_rand.Next(-10, 11) / 200f, _rand.Next(-10, 11) / 200f),
                    ScaleVelocity = _rand.NextFloat() / 10f,
                    RotationVelocity = _rand.NextFloat() / 10f,
                };
        }
    }
}
