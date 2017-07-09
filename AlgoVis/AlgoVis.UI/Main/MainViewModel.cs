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
using AlgoVis.Presenation;
using AlgoVis.UI.AlgorithmDisplay;
using AlgoVis.UI.AlgorithmList;
using AlgoVis.UI.Messages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.UI.Main
{
    public class MainViewModel : ReactiveObject
    {
        public AlgorithmListViewModel AlgorithmList { get; } = new AlgorithmListViewModel();

        public AlgorithmDisplayViewModel CurrentAlgorithm { [ObservableAsProperty] get; } = null;

        public MainViewModel()
        {
            MessageBus.Current.Listen<OpenAlgorithmMessage>()
                .Select(m => new AlgorithmDisplayViewModel(m.Algorithm))
                .ToPropertyEx(this, x => x.CurrentAlgorithm);

            Seed();
        }

        private void Seed()
        {
            AlgorithmList.Algorithms.Add(new CompiledAlgorithm("Bubble sort", "A sorting algorithm.", Enumerable.Empty<IAction>(), null));
            AlgorithmList.Algorithms.Add(new Quicksort().Build());
        }

        [Algorithm("Quicksort", Description = "A sorting algorithm.")]
        private class Quicksort : AlgorithmBase
        {
            public override object Display { get; } = null;

            [Action("Add", "Adds a new item to the array.")]
            [Param("Value", typeof(int))]
            public void AddItem(int value)
            {
                
            }

            [Action("Sort", "Sorts the array.")]
            public void Sort()
            {

            }
        }
    }
}
