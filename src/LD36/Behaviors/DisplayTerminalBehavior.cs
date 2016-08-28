using Coldsteel;
using Coldsteel.Rendering;
using LD36.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    class DisplayTerminalBehavior : Behavior
    {
        private TextRenderer[] _lines;

        public DisplayTerminalBehavior(TextRenderer[] lines)
        {
            _lines = lines;
        }

        public override void Initialize()
        {
            ClearDisplay();
            DisplayTerminalLines();
        }

        public override void Update()
        {
            ClearDisplay();
            DisplayTerminalLines();
        }

        private void ClearDisplay()
        {
            foreach (var line in _lines)
                line.Text = string.Empty;
        }

        private void DisplayTerminalLines()
        {
            var r = 0;
            foreach (var line in Terminal.Lines)
                _lines[r++].Text = line;
        }
    }
}
