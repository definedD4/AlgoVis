using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
