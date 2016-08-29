using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class StateMachineTriggerConfigurator<T>
    {
        private StateInfoConfigurator<T> _stateInfoConfigurator;

        private StateMachineTrigger<T> _trigger;

        public StateMachineTriggerConfigurator(StateInfoConfigurator<T> stateInfoConfigurator, StateMachineTrigger<T> trigger)
        {
            _stateInfoConfigurator = stateInfoConfigurator;
            _trigger = trigger;
        }

        public StateInfoConfigurator<T> When(Func<T, bool> condition)
        {
            _trigger.Condition = condition;
            return _stateInfoConfigurator;
        }
    }
}
