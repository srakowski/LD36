using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class FollowBehavior : Behavior
    {
        private GameObject _subject;

        public FollowBehavior(GameObject subject)
        {
            _subject = subject;
        }

        public override void Update()
        {
            Transform.LocalPosition = _subject.Transform.Position;
        }
    }
}
