using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace AlgoVis.UI.AlgorithmActionParam
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmActionParamView.xaml
    /// </summary>
    public partial class AlgorithmActionParamView : UserControl, IViewFor<AlgorithmActionParamViewModel>
    {
        public AlgorithmActionParamView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Name, v => v.ParamNameTextBlock.Text);
            this.Bind(ViewModel, vm => vm.Input, v => v.ValueTextBox.Text);

            this.WhenAnyValue(x => x.ViewModel.Valid)
                .Select(valid => valid ? Colors.Transparent : Colors.Red)
                .Subscribe(color => this.Background = new SolidColorBrush(color));

        }

        public AlgorithmActionParamViewModel ViewModel
        {
            get { return (AlgorithmActionParamViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(AlgorithmActionParamViewModel), typeof(AlgorithmActionParamView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmActionParamViewModel)value; }
        }
    }
}
