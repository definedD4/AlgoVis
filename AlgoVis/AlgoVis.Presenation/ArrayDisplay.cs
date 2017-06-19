using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoVis.DataModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.Presenation
{
    public class ArrayDisplay : ReactiveObject
    {
        private readonly Func<ItemModel, object> _selector;

        [Reactive] public ArrayModel Model { get; set; }

        public IReactiveDerivedList<object> DisplayItems { [ObservableAsProperty] get; }

        public ArrayDisplay(ArrayModel model, Func<ItemModel, object> selector)
        {
            Model = model;
            _selector = selector;

            this.WhenAnyValue(x => x.Model)
                .Select(m => m?.Items.CreateDerivedCollection(_selector))
                .ToPropertyEx(this, x => x.DisplayItems);
        }
    }
}
