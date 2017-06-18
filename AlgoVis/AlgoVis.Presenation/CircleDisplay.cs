using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AlgoVis.Presenation
{
    public class CircleDisplay : ReactiveObject
    {
        [Reactive] public object Content { get; set; }

        [Reactive] public Color Background { get; set; } = Colors.Red;
    }
}
