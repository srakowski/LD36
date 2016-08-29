using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Input;
using Coldsteel.Particles;

namespace Coldsteel
{
    public class GameStateManager
    {
        private GameState _state;

        private StateInfo<GameState> _stateInfo;

        private GameState _pendingState;

        private InputManager _input;

        private ContentManager _content;

        private GameStage _stage;

        private Dictionary<string, StateInfo<GameState>> _stateInfos = new Dictionary<string, StateInfo<GameState>>();

        public GameStateManager(InputManager input, 
            ContentManager content, GameStage stage)
        {
            this._input = input;
            this._content = content;
            this._stage = stage;
        }

        public StateInfoConfigurator<GameState> AddState<T>(string key) where T : GameState, new()
        {
            var stateInfo = new StateInfo<GameState>(key, typeof(T));
            _stateInfos[key] = stateInfo;
            return new StateInfoConfigurator<GameState>(stateInfo);
        }

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            _stage.Initialize(graphicsDevice);
            SwapState();
        }

        public void Start<T>() where T : GameState, new()
        {
            Start(typeof(T));
        }

        protected void Start(Type type)
        {
            _pendingState = Activator.CreateInstance(type) as GameState;
        }

        public void Exit()
        {
        }

        internal void Update(GameTime gameTime)
        {
            var triggers = _stateInfo.Triggers ?? new List<StateMachineTrigger<GameState>>();
            foreach (var trigger in triggers)
                if (trigger.Condition(_state))
                {
                    Start(_stateInfos[trigger.StateKey].Type);
                    break;
                } 

            InputDevices.Update();
            _state?.Update(gameTime);
            SwapState();
        }

        private void SwapState()
        {
            if (_pendingState == null)
                return;

            _content.Reset();
            _pendingState.State = this;
            _pendingState.Input = this._input;
            _pendingState.Load = this._content;
            _pendingState.Stage = this._stage;
            _pendingState.Layers = new LayerManager();
            _pendingState.World = new World(_pendingState, new ParticleManager(_pendingState.Layers));
            _pendingState.Camera = _pendingState.World.AddCamera();
            _pendingState.Preload();
            _state = _pendingState;
            _pendingState = null;
            _state.Create();
        }

        internal void Draw(GameTime gameTime)
        {
            _state?.Render(gameTime);
        }
    }
}
