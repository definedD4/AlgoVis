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

namespace AlgoVis.Sandbox.UITest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            int idx = int.Parse(IndexTextBox.Text);
            string value = ValueTextBox.Text;

            ItemsControl.Items.Insert(idx, value);
        }

        private void SwapItems(object sender, RoutedEventArgs e)
        {
            int first = int.Parse(SwapFirstTextBox.Text);
            int second = int.Parse(SwapSecondTextBox.Text);

            var temp = ItemsControl.Items[first];
            ItemsControl.Items[first] = ItemsControl.Items[second];
            ItemsControl.Items[second] = temp;
        }
    }
}
