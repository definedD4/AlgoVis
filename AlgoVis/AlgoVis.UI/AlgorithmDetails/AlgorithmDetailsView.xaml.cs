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

namespace AlgoVis.UI.AlgorithmDetails
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmDetailsView.xaml
    /// </summary>
    public partial class AlgorithmDetailsView : UserControl, IViewFor<AlgorithmDetailsViewModel>
    {
        public AlgorithmDetailsView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Name, v => v.TitleTextBlock.Text);

            this.OneWayBind(ViewModel, vm => vm.Description, v => v.DescriptionTextBlock.Text);

            this.BindCommand(ViewModel, vm => vm.Open, v => v.OpenButton);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmDetailsViewModel)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(AlgorithmDetailsViewModel), typeof(AlgorithmDetailsView), new PropertyMetadata(default(AlgorithmDetailsViewModel)));

        public AlgorithmDetailsViewModel ViewModel
        {
            get { return (AlgorithmDetailsViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
