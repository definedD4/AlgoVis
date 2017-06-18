using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoVis.Presenation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.UI.Main
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Content = new CircleDisplay
            {
                Content = 42
            };
        }

        [Reactive] public object Content { get; set; }
    }
}
