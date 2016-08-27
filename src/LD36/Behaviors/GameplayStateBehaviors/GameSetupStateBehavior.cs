using Coldsteel;
using LD36.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LD36.Behaviors.GameplayStateBehaviors
{
    public class GameSetupBehavior : Behavior
    {
        public bool SetupComplete => !String.IsNullOrEmpty(_name) && _gender != Gender.Invalid;

        private string _name = null;

        private Gender _gender = Gender.Invalid;

        public override void Initialize()
        {
        }
    }
}
