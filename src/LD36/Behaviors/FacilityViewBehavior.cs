using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;
using LD36.ViewModels;

namespace LD36.Behaviors
{
    class FacilityViewBehavior : Behavior
    {
        private FacilityViewModel _vm;

        public FacilityViewBehavior(FacilityViewModel vm)
        {
            this._vm = vm;
        }
    }
}
