using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using AlgoVis.AlgorithmConstruction;
using AlgoVis.Core;
using AlgoVis.Core.ActionStatements;
using AlgoVis.DataModel;
using AlgoVis.Presenation;
using AlgoVis.UI.AlgorithmDisplay;
using AlgoVis.UI.AlgorithmList;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.UI.Main
{
    public class MainViewModel : ReactiveObject
    {
        public AlgorithmListViewModel AlgorithmList { get; } = new AlgorithmListViewModel();

        public AlgorithmDisplayViewModel CurrentAlgorithm { [ObservableAsProperty] get; }

        public MainViewModel()
        {
            AlgorithmList.SelectAlgorithm
                .Select(a => a != null ? new AlgorithmDisplayViewModel(a) : null)
                .ToPropertyEx(this, x => x.CurrentAlgorithm);

            Seed();
        }

        private void Seed()
        {
            AlgorithmList.Algorithms.Add(new CompiledAlgorithm("Quicksort" , "A sorting algorithm with O(n*log(n)) complexity.", Enumerable.Empty<IAction>(), null));
            AlgorithmList.Algorithms.Add(new CompiledAlgorithm("Bubble sort", "A sorting algorithm that.", Enumerable.Empty<IAction>(), null));
        }
    }
}
