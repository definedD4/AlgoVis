using System.Windows;
using System.Windows.Controls;
// ReSharper disable once RedundantUsingDirective
using AlgoVis.Controls; // to solve problem with runtime assembly loading

namespace AlgoVis.Presenation
{
    /// <summary>
    /// Interaction logic for DisplayHost.xaml
    /// </summary>
    public partial class DisplayHost : UserControl
    {
        public DisplayHost()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DisplayContentProperty = DependencyProperty.Register(
            nameof(DisplayContent), typeof(object), typeof(DisplayHost), new PropertyMetadata(default(object)));

        public object DisplayContent
        {
            get { return (object) GetValue(DisplayContentProperty); }
            set { SetValue(DisplayContentProperty, value); }
        }
    }
}
