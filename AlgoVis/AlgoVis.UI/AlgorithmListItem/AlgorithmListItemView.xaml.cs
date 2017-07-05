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
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmListItem
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmListItemView.xaml
    /// </summary>
    public partial class AlgorithmListItemView : UserControl, IViewFor<AlgorithmListItemViewModel>
    {
        public AlgorithmListItemView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.DisplayName, v => v.DisplayNameTextBox.Text);

            this.BindCommand(ViewModel, vm => vm.Open, v => v.DoubleClickMouseBinding);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmListItemViewModel)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(AlgorithmListItemViewModel), typeof(AlgorithmListItemView), new PropertyMetadata(default(AlgorithmListItemViewModel)));

        public AlgorithmListItemViewModel ViewModel
        {
            get { return (AlgorithmListItemViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
