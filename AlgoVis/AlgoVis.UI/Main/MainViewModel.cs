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
            AlgorithmList.Algorithms.Add(new BubleSort().Build());
            AlgorithmList.Algorithms.Add(new Quicksort().Build());
        }

        [Algorithm("Quicksort", Description = "A sorting algorithm.")]
        private class Quicksort : AlgorithmBase
        {
            private readonly ArrayModel _model = new ArrayModel();

            public override object Display { get; }

            public Quicksort()
            {
                Display = new ArrayDisplay(_model, model => new CircleDisplay(model));
                _model.Add(new ItemModel(2));
                _model.Add(new ItemModel(7));
                _model.Add(new ItemModel(3));
                _model.Add(new ItemModel(5));
                _model.Add(new ItemModel(9));
            }

            [Action("Add", "Adds a new item to the array.")]
            [Param("Value", typeof(int))]
            public IEnumerable<IActionStatement> AddItem(int value)
            {
                _model.Add(new ItemModel(value));

                yield return new ContinueStatement();
            }

            [Action("Generate", "Generate new randow sequence.")]
            [Param("Length", typeof(int))]
            public IEnumerable<IActionStatement> GenerateRandom(int length)
            {
                var random = new Random();

                _model.Clear();
                for (int i = 0; i < length; i++)
                {
                    _model.Add(new ItemModel(random.Next(1, length)));
                }

                yield return new ContinueStatement();
            }

            [Action("Sort", "Sorts the array.")]
            public IEnumerable<IActionStatement> Sort()
            {
                Console.WriteLine("Start sort");
                int len = _model.Items.Count;

                int l = 0;
                int r = len - 1;
                foreach (var act in SortRange(l, r)) yield return act;
                Console.WriteLine("End sort");
            }

            private IEnumerable<IActionStatement> SortRange(int left, int right)
            {
                Console.WriteLine($"Sorting from {left} to {right}");
                if (right - left >= 1)
                { 
                    int l = left;
                    int r = right;
                    var m = (l + r) / 2;
                    int pivot = (int) _model[m].Value;
                    _model[l].Background = Colors.Green;
                    _model[r].Background = Colors.Blue;
                    _model[m].Background = Colors.Yellow;
                    while (l <= r)
                    {
                        while ((int) _model[l].Value < pivot)
                        {
                            _model[l].Background = Colors.Red;
                            l++;
                            _model[l].Background = Colors.Green;
                        }
                        while ((int) _model[r].Value > pivot)
                        {
                            _model[r].Background = Colors.Red;
                            r--;
                            _model[r].Background = Colors.Blue;
                        }

                        if (l <= r)
                        {
                            Console.WriteLine($"Swaping {l} and {r}");
                            _model[l].Background = Colors.Red;
                            _model[r].Background = Colors.Red;
                            _model.Swap(l, r);
                            l++;
                            r--;
                            _model[l].Background = Colors.Green;
                            _model[r].Background = Colors.Blue;
                            yield return new WaitStatement(TimeSpan.FromSeconds(1));
                        }
                    }
                    Console.WriteLine($"l = {l} r = {r}");
                    _model[l].Background = Colors.Red;
                    _model[r].Background = Colors.Red;
                    _model[m].Background = Colors.Red;
                    foreach (var act in SortRange(left, r)) yield return act;
                    foreach (var act in SortRange(l, right)) yield return act;
                }
            }
        }

        [Algorithm("BubleSort", Description = "A sorting algorithm.")]
        private class BubleSort : AlgorithmBase
        {
            private readonly ArrayModel _model = new ArrayModel();

            public override object Display { get; }

            public BubleSort()
            {
                Display = new ArrayDisplay(_model, model => new CircleDisplay(model));
                _model.Add(new ItemModel(2));
                _model.Add(new ItemModel(7));
                _model.Add(new ItemModel(3));
                _model.Add(new ItemModel(5));
                _model.Add(new ItemModel(9));
            }

            [Action("Add", "Adds a new item to the array.")]
            [Param("Value", typeof(int))]
            public IEnumerable<IActionStatement> AddItem(int value)
            {
                _model.Add(new ItemModel(value));

                yield return new ContinueStatement();
            }

            [Action("Generate", "Generate new randow sequence.")]
            [Param("Length", typeof(int))]
            public IEnumerable<IActionStatement> GenerateRandom(int length)
            {
                var random = new Random();

                _model.Clear();
                for (int i = 0; i < length; i++)
                {
                    _model.Add(new ItemModel(random.Next(1, length)));
                }

                yield return new ContinueStatement();
            }

            [Action("Sort", "Sorts the array.")]
            public IEnumerable<IActionStatement> Sort()
            {
                Console.WriteLine("Start sort");
                int len = _model.Items.Count;

                bool swap;
                do
                {
                    swap = false;
                    for (int i = 0; i < len - 1; i++)
                    {
                        _model[i].Background = Colors.Blue;
                        _model[i + 1].Background = Colors.Yellow;

                        yield return new WaitStatement(TimeSpan.FromSeconds(1));

                        if ((int)_model[i].Value > (int)_model[i + 1].Value)
                        {                          
                            _model.Swap(i, i + 1);                           
                            swap = true;

                            yield return new WaitStatement(TimeSpan.FromSeconds(1));                            
                        }                       
                        _model[i].Background = Colors.Red;
                        _model[i + 1].Background = Colors.Red;
                    }
                } while (swap);
            }
        }
    }
}
