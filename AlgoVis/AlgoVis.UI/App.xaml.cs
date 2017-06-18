using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AlgoVis.UI.Main;
using ReactiveUI;
using Splat;

namespace AlgoVis.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterViews();

            new MainView
            {
                ViewModel = new MainViewModel()
            }.Show();
        }

        private void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
        }
    }
}
