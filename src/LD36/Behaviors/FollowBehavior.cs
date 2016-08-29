using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class FollowBehavior : Behavior
    {
        public GameObject Subject { get; set; }

        public FollowBehavior(GameObject subject)
        {
            Subject = subject;
        }

        public override void Update()
        {
            Transform.LocalPosition = Subject.Transform.Position;
        }
    }
}
