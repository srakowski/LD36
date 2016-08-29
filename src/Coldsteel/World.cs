using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Particles;
using Coldsteel.Physics;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class World
    {
        public GameState GameState { get; private set; }

        private List<GameObject> _gameObjects = new List<GameObject>();

        private PhysicalWorld _physicalWorld;

        internal PhysicalWorld PhysicalWorld => _physicalWorld;

        private ParticleManager _particles;

        internal ParticleManager Particles => _particles;

        private Camera _camera;

        public Vector2 Gravity
        {
            get { return PhysicalWorld?.Gravity ?? Vector2.Zero; }
            set { PhysicalWorld.Gravity = value; }
        }

        internal World(GameState gameState, ParticleManager particles)
        {
            GameState = gameState;
            _physicalWorld = new PhysicalWorld();
            _particles = particles;
        }

        public GameObject AddGameObject(params string[] tags)
        {
            var go = new GameObject(this);
            go.Tags = tags;
            _gameObjects.Add(go);
            return go;
        }

        internal Camera AddCamera()
        {
            _camera = new Camera(this);
            return _camera;
        }

        internal void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        internal void Update(GameTime gameTime)
        {
            _physicalWorld.Update(gameTime);
            var gameObjectsToUpdate = _gameObjects.ToArray();
            foreach (var go in gameObjectsToUpdate)
                go.Update(gameTime);
            _camera.Update(gameTime);
            foreach (var go in gameObjectsToUpdate)
                go.UpdateCoroutines(gameTime);
            _camera.Update(gameTime);
            _particles.Update(gameTime);
        }
    }
}
