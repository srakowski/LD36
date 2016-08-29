using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public struct StateInfo<T>
    {
        public string Key;
        public Type Type;
        public List<StateMachineTrigger<T>> Triggers;
        public StateInfo(string key, Type type)
        {
            Key = key;
            Type = type;
            Triggers = new List<StateMachineTrigger<T>>();
        }
    }
}
