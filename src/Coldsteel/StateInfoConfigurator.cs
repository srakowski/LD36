using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class StateInfoConfigurator<T>
    {
        private StateInfo<T> _statInfo;

        public StateInfoConfigurator(StateInfo<T> stateInfo)
        {
            _statInfo = stateInfo;
        }

        public StateMachineTriggerConfigurator<T> Trigger(string stateKey)
        {
            var trigger = new StateMachineTrigger<T>(stateKey);
            _statInfo.Triggers.Add(trigger);
            return new StateMachineTriggerConfigurator<T>(this, trigger);
        }
    }
}
