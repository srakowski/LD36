using System;
using System.Collections.Generic;
using System.Text;
using LD36.Models;

namespace LD36.ViewModels
{
    class HudViewModel
    {
        private GameplayModel _model;

        public HudViewModel(GameplayModel model)
        {
            this._model = model;
        }
    }
}
