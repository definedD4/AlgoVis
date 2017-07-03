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
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmDisplay
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmDisplayView.xaml
    /// </summary>
    public partial class AlgorithmDisplayView : UserControl, IViewFor<AlgorithmDisplayViewModel>
    {
        public AlgorithmDisplayView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.AlgorithmTitle, v => v.TitleTextBox.Text);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmDisplayViewModel)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(AlgorithmDisplayViewModel), typeof(AlgorithmDisplayView), new PropertyMetadata(default(AlgorithmDisplayViewModel)));

        public AlgorithmDisplayViewModel ViewModel
        {
            get { return (AlgorithmDisplayViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
