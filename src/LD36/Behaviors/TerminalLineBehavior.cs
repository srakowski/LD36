using Coldsteel;
using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD36.Behaviors
{
    public class TerminalLineBehavior : Behavior
    {
        public string Text
        {
            get { return Renderer.As<TextRenderer>().Text; }
            set { Renderer.As<TextRenderer>().Text = value; }
        }
    }
}
