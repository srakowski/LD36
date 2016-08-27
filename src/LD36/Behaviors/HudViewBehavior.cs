using System;
using System.Collections.Generic;
using System.Text;
using LD36.ViewModels;
using Coldsteel;

namespace LD36.Behaviors
{
    class HudViewBehavior : Behavior
    {
        private HudViewModel _vm;

        public HudViewBehavior(HudViewModel vm)
        {
            this._vm = vm;
        }
    }
}
