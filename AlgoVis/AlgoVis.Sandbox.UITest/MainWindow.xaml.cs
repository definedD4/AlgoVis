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
using AlgoVis.DataModel;
using AlgoVis.Presenation;

namespace AlgoVis.Sandbox.UITest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ArrayModel _arrayModel = new ArrayModel();

        public ArrayDisplay Display { get; }

        public MainWindow()
        {
            InitializeComponent();
            
            Display = new ArrayDisplay(_arrayModel, x => new CircleDisplay(x));
            Host.DisplayContent = Display;
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            int idx = int.Parse(IndexTextBox.Text);
            string value = ValueTextBox.Text;

            _arrayModel.Insert(idx, new ItemModel(value));
        }

        private void SwapItems(object sender, RoutedEventArgs e)
        {
            int first = int.Parse(SwapFirstTextBox.Text);
            int second = int.Parse(SwapSecondTextBox.Text);

            _arrayModel.Swap(first, second);
        }
    }
}
