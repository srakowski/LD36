using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    /// <summary>
    /// Tactical state. Player has to respond to technical issues, assign
    /// employees to tickets, install hardware, etc.
    /// Tasks vs Tickets
    /// </summary>
    class OperateStateBehavior : Behavior
    {
        private const int PERIOD_LENGTH_IN_MINUTES = 3;

        public float TimeRemainingInPeriod => (float)Math.Round(_periodClock, 2);

        public bool HasPeriodEnded => TimeRemainingInPeriod <= 0f;

        private float _periodClock = 0;

        public override void Initialize()
        {
            _periodClock = PERIOD_LENGTH_IN_MINUTES * 60f;
        }

        public override void Update()
        {
            UpdatePeriodClock();
        }

        private void UpdatePeriodClock()
        {
            _periodClock -= GameTime.DeltaSeconds;
            _periodClock = MathHelper.Clamp(_periodClock, 0f, float.MaxValue);
        }
    }
}
