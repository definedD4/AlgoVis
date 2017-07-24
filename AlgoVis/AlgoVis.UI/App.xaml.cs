using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AlgoVis.UI.AlgorithmAction;
using AlgoVis.UI.AlgorithmDetails;
using AlgoVis.UI.AlgorithmDisplay;
using AlgoVis.UI.AlgorithmList;
using AlgoVis.UI.AlgorithmListItem;
using AlgoVis.UI.Main;
using ReactiveUI;
using Splat;
using AlgoVis.UI.AlgorithmActionParam;

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
            Locator.CurrentMutable.Register(() => new AlgorithmListView(), typeof(IViewFor<AlgorithmListViewModel>));
            Locator.CurrentMutable.Register(() => new AlgorithmListItemView(), typeof(IViewFor<AlgorithmListItemViewModel>));
            Locator.CurrentMutable.Register(() => new AlgorithmDisplayView(), typeof(IViewFor<AlgorithmDisplayViewModel>));
            Locator.CurrentMutable.Register(() => new AlgorithmDetailsView(), typeof(IViewFor<AlgorithmDetailsViewModel>));
            Locator.CurrentMutable.Register(() => new AlgorithmActionView(), typeof(IViewFor<AlgorithmActionViewModel>));
            Locator.CurrentMutable.Register(() => new AlgorithmActionParamView(), typeof(IViewFor<AlgorithmActionParamViewModel>));
        }
    }
}
