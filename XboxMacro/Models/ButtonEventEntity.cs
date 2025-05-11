using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxMacro.Models
{
    public class ButtonEventEntity
    {
        public Action? A { get; set; }
        public Action? B { get; set; }
        public Action? Y { get; set; }
        public Action? X { get; set; }
        public Action? Back { get; set; }
        public Action? DpadDown { get; set; }
        public Action? DPadLeft { get; set; }
        public Action? DPadRight { get; set; }
        public Action? DPadUp { get; set; }
        public Action? LeftShoulder { get; set; }
        public Action? RightShoulder { get; set; }
        public Action? LeftThumb { get; set; }
        public Action? RightThumb { get; set; }
        public Action? Start { get; set; }
    }
}
