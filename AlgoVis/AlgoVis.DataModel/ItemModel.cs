using System.Windows;
using System.Windows.Media;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.DataModel
{
    public class ItemModel : ReactiveObject
    {
        [Reactive] public object Value { get; set; }

        [Reactive] public Color Background { get; set; } = Colors.Red;

        [Reactive] public Vector Offset { get; set; } = new Vector(0d, 0d);

        public ItemModel(object value)
        {
            Value = value;
        }
    }
}
