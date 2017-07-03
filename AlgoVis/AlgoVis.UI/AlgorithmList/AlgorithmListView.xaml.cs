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

namespace AlgoVis.UI.AlgorithmList
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmListView.xaml
    /// </summary>
    public partial class AlgorithmListView : UserControl, IViewFor<AlgorithmListViewModel>
    {
        public AlgorithmListView()
        {
            InitializeComponent();

            this.Bind(ViewModel, vw => vw.SearchString, v => v.SerachTextBox.Text);

            this.OneWayBind(ViewModel, vm => vm.DisplayItems, v => v.AlgorithmsListBox.ItemsSource);

            this.BindCommand(ViewModel, vm => vm.Add, v => v.AddButton);

            this.Bind(ViewModel, vm => vm.SelectedAlgorithm, v => v.AlgorithmsListBox.SelectedItem);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmListViewModel)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            nameof(ViewModel), typeof(AlgorithmListViewModel), typeof(AlgorithmListView), new PropertyMetadata(default(AlgorithmListViewModel)));

        public AlgorithmListViewModel ViewModel
        {
            get { return (AlgorithmListViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
