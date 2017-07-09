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

namespace AlgoVis.UI.AlgorithmAction
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmActionView.xaml
    /// </summary>
    public partial class AlgorithmActionView : UserControl, IViewFor<AlgorithmActionViewModel>
    {
        public AlgorithmActionView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Name, v => v.NameTextBlock.Text);
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(AlgorithmActionViewModel), typeof(AlgorithmActionView), new PropertyMetadata(default(AlgorithmActionViewModel)));

        public AlgorithmActionViewModel ViewModel
        {
            get { return (AlgorithmActionViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AlgorithmActionViewModel) value; }
        }
    }
}
