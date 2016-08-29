using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class BehaviorStateMachine : GameObjectComponent
    {
        private Behavior _currentState;

        private StateInfo<Behavior> _currentStateInfo;

        private Dictionary<string, StateInfo<Behavior>> _stateInfo = new Dictionary<string, StateInfo<Behavior>>();

        public StateInfoConfigurator<Behavior> AddState<T>(string key) where T : Behavior, new()
        {
            var stateInfo = new StateInfo<Behavior>(key, typeof(T));
            _stateInfo[key] = stateInfo;
            return new StateInfoConfigurator<Behavior>(stateInfo);
        }

        public void Start(string key)
        {
            if (_currentState != null)
            {
                GameObject.RemoveGameObjectComponent(_currentState);
                _currentState.Dispose();
            }

            _currentStateInfo = _stateInfo[key];
            _currentState = Activator.CreateInstance(_currentStateInfo.Type) as Behavior;
            GameObject.AddGameObjectComponent(_currentState);
        }

        public override void Update()
        {
            var triggers = _currentStateInfo.Triggers;
            foreach (var trigger in triggers)
                if (trigger.Condition(_currentState))
                {
                    Start(trigger.StateKey);
                    break;
                }

        }
    }
}
