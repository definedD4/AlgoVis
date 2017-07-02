using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using AlgoVis.DataModel;

namespace AlgoVis.Presenation
{
    public class CircleDisplay : ReactiveObject
    {
        [Reactive] public ItemModel Model { get; set; }

        public object Content { [ObservableAsProperty]get; }

        public Color Background { [ObservableAsProperty]get; }

        public Vector Offset { [ObservableAsProperty]get; }

        public int Index { [ObservableAsProperty]get; }

        public CircleDisplay(ItemModel model)
        {
            Model = model;

            this.WhenAnyValue(x => x.Model.Value)
                .ToPropertyEx(this, x => x.Content);

            this.WhenAnyValue(x => x.Model.Background)
                .ToPropertyEx(this, x => x.Background);

            this.WhenAnyValue(x => x.Model.Index)
                .ToPropertyEx(this, x => x.Index);
        }
    }
}
