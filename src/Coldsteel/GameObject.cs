﻿using System;
using System.Collections.Generic;
using Coldsteel.Audio;
using Coldsteel.Input;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using Coldsteel.Physics;
using Coldsteel.Particles;
using System.Linq;

namespace Coldsteel
{
    public class GameObject
    {
        /// <summary>
        /// Tags are used to identify what type of GameObject this GameObject is.
        /// </summary>
        public string[] Tags { get; internal set; }

        public void ClearBehaviors()
        {
            _behaviors.Clear();
        }


        /// <summary>
        /// Used to perform common modifications to the state of the 
        /// GameObject such as rotating or transforming.
        /// </summary>
        public GameObjectConfigurator Set { get; private set; }


        /// <summary>
        /// Use to add GameObjectComponents to the GameObject.
        /// </summary>
        public GameObjectComponentAdder Add { get; private set; }


        /// <summary>
        /// If this GameObject is a child of another GameObject and not the World
        /// then this will be populated with the parent. Being a child of another
        /// GameObject affects components such as the Transform. The transform of
        /// a child GameObject is relative to the Parent.
        /// </summary>
        public GameObject Parent { get; private set; }


        private List<GameObject> _children = new List<GameObject>();

        /// <summary>
        /// The Children of this GameObject. Some behaviors are relative
        /// to this GameObject.
        /// </summary>
        public IEnumerable<GameObject> Children => _children;


        /// <summary>
        /// The World this GameObject belongs to.
        /// </summary>
        public World World { get; private set; }


        /// <summary>
        /// Gets the current game state.
        /// </summary>
        public GameState GameState => World.GameState;


        /// <summary>
        /// Gets the ParticleManager for internal use.
        /// </summary>
        internal ParticleManager Particles => World?.Particles;


        /// <summary>
        /// Gets the Camera.
        /// </summary>
        public Camera Camera => World?.GameState?.Camera;


        /// <summary>
        /// Gets the StateManager.
        /// </summary>
        public GameStateManager State => World?.GameState?.State;


        /// <summary>
        /// Gets the GameStage.
        /// </summary>
        public GameStage Stage => World?.GameState?.Stage;


        /// <summary>
        /// Gets the ContentManager.
        /// </summary>
        public ContentManager Content => World?.GameState?.Load;


        /// <summary>
        /// Gets the LayerManager.
        /// </summary>
        public LayerManager Layers => World?.GameState?.Layers;


        /// <summary>
        /// Gets the InputManager.
        /// </summary>
        public InputManager Input => World?.GameState?.Input;


        /// <summary>
        /// Gets the Tranform.
        /// </summary>
        public Transform Transform { get; private set; }


        /// <summary>
        /// Gets the RigidBody.
        /// </summary>
        public RigidBody RigidBody { get; private set; }


        /// <summary>
        /// Gets the Collider.
        /// </summary>
        public Collider Collider { get; private set; }


        /// <summary>
        /// Gets the AudioSource.
        /// </summary>
        public AudioSource AudioSource { get; private set; }


        /// <summary>
        /// Gets the ParticleEmitter.
        /// </summary>
        public ParticleEmitter ParticleEmitter { get; private set; }


        /// <summary>
        /// Gets the StateMachine component;
        /// </summary>
        public BehaviorStateMachine StateMachine { get; private set; }


        /// <summary>
        /// Gets or sets game Data.
        /// </summary>
        public object Data
        {
            get { return GameState?.Data; }
            set { GameState.Data = value; }
        }


        /// <summary>
        /// Gets the AnimationManager, if SpriteSheetRenderer present.
        /// </summary>
        public AnimationManager Animations => Renderer?.As<SpriteSheetRenderer>()?.Animations;


        private Layer _layer;


        /// <summary>
        /// Gets the Layer this GameObject will be rendered to.
        /// </summary>
        public Layer Layer
        {
            get { return _layer; }
            set
            {
                if (this.Renderer != null)
                    _layer?.RemoveRenderer(this.Renderer);

                _layer = value;

                if (this.Renderer != null)
                    _layer?.AddRenderer(this.Renderer);
            }
        }


        private Renderer _renderer;

        /// <summary>
        /// Gets the Renderer, if any.
        /// </summary>
        public Renderer Renderer
        {
            get { return _renderer; }
            set
            {
                if (_renderer != null)
                    Layer?.RemoveRenderer(_renderer);

                _renderer = value;

                if (_renderer != null)
                    Layer?.AddRenderer(_renderer);
            }
        }


        private List<Behavior> _behaviors = new List<Behavior>();

        /// <summary>
        /// Gets the Behaviors.
        /// </summary>
        public IEnumerable<Behavior> Behaviors => _behaviors;


        /// <summary>
        /// Gets the GameTime.
        /// </summary>
        public IGameTime GameTime { get; private set; }


        /// <summary>
        /// Construct a GameObject for the provided World.
        /// </summary>
        /// <param name="world"></param>
        internal GameObject(World world)
        {
            this.World = world;
            this.Layer = world.GameState.Layers.Default;
            this.Set = new GameObjectConfigurator(this);
            this.Add = new GameObjectComponentAdder(this);
            this.AddGameObjectComponent(new Transform());
        }


        /// <summary>
        /// Adds a child GameObject.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public GameObject AddGameObject(params string[] tags)
        {
            var gameObject = World.AddGameObject(tags);
            gameObject.Parent = this;
            _children.Add(gameObject);
            return gameObject;
        }

        private void RemoveGameObject(GameObject gameObject)
        {
            _children.Remove(gameObject);
            gameObject.Parent = null;
        }

        private bool _isKilled = false;

        /// <summary>
        /// Kills this GameObject and all its children.
        /// </summary>
        public void Kill(bool now = false)
        {
            _isKilled = true;
            if (now)
                DoKill(now);
        }


        /// <summary>
        /// Adds or updates a component for this GameObject.
        /// </summary>
        /// <param name="component"></param>
        internal void AddGameObjectComponent(GameObjectComponent component)
        {
            component.GameObject = this;

            this.Transform = component as Transform ?? Transform;
            this.Renderer = component as Renderer ?? Renderer;
            this.Collider = component as Collider ?? Collider;
            this.RigidBody = component as RigidBody ?? RigidBody;
            this.AudioSource = component as AudioSource ?? AudioSource;
            this.ParticleEmitter = component as ParticleEmitter ?? ParticleEmitter;
            this.StateMachine = component as BehaviorStateMachine ?? StateMachine;
            if (component is Behavior)
                _behaviors.Add(component as Behavior);

            component.Initialize();
        }


        /// <summary>
        /// Removes a GameObjectComponent from this GameObject.
        /// </summary>
        /// <param name="component"></param>
        /// <remarks>Currently only removes behaviors TODO: remove any</remarks>
        public void RemoveGameObjectComponent(GameObjectComponent component)
        {
            if (component is Behavior)
            {
                _behaviors.Remove(component as Behavior);
                component.GameObject = null;
            }
            if (component is Renderer)
                this.Renderer = null;

            if (component is Collider)
                this.Collider = null;
        }


        /// <summary>
        /// Handles collisions with other GameObjects.
        /// </summary>
        /// <param name="withGameObject"></param>
        internal void HandlCollision(GameObject withGameObject)
        {
            ForEachBehavior(b => b.OnCollision(withGameObject));
        }


        /// <summary>
        /// Updates the GameObject state.
        /// </summary>
        /// <param name="gameTime"></param>
        internal virtual void Update(GameTime gameTime)
        {
            if (_isKilled)
                return;

            this.GameTime = new GameTimeWrapper(gameTime);
            StateMachine?.Update();
            ForEachBehavior(b => b.Update());
            this.Renderer?.Update();

            if (_isKilled)
                DoKill(true);
        }

        private void DoKill(bool now)
        {
            Renderer = null;
            Transform?.Dispose();
            World.RemoveGameObject(this);
            Parent?.RemoveGameObject(this);
            var childrenToKill = Children.ToArray();
            foreach (var child in childrenToKill)
                child.Kill(now);
        }


        /// <summary>
        /// Updates any Coroutines this GameObject has in flight.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void UpdateCoroutines(GameTime gameTime)
        {
            if (_isKilled)
                return;

            this.GameTime = new GameTimeWrapper(gameTime);
            ForEachBehavior(b => b.UpdateCoroutines());
        }


        /// <summary>
        /// Helper method used to do various updates to Behaviors.
        /// </summary>
        /// <param name="action"></param>
        private void ForEachBehavior(Action<Behavior> action)
        {
            var behaviorsToUpdate = _behaviors.ToArray();
            foreach (var behavior in behaviorsToUpdate)
                action(behavior);
        }
    }
}
