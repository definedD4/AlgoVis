using System;
using System.Reactive.Linq;
using AlgoVis.Core;
using AlgoVis.UI.AlgorithmListItem;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.UI.AlgorithmList
{
    public class AlgorithmListViewModel : ReactiveObject
    {
        public IReactiveList<CompiledAlgorithm> Algorithms { get; } = new ReactiveList<CompiledAlgorithm>();

        public IReactiveDerivedList<AlgorithmListItemViewModel> DisplayItems { [ObservableAsProperty]get; }

        [Reactive] public string SearchString { get; set; }

        [Reactive] public AlgorithmListItemViewModel SelectedAlgorithm { get; set; }

        public ReactiveCommand Add { get; }

        public ReactiveCommand<AlgorithmListItemViewModel, CompiledAlgorithm> SelectAlgorithm { get; }

        public AlgorithmListViewModel()
        {
            this.WhenAnyValue(x => x.SearchString)
                .Select(search =>
                    Algorithms.CreateDerivedCollection(
                        a => new AlgorithmListItemViewModel(a),
                        filter: a => StringMatches(a.Name, search)
                        )
                )
                .ToPropertyEx(this, x => x.DisplayItems);

            Add = ReactiveCommand.Create(() => throw new NotImplementedException());

            SelectAlgorithm = ReactiveCommand.Create<AlgorithmListItemViewModel, CompiledAlgorithm>(vm => vm?.Algorithm);

            this.WhenAnyValue(x => x.SelectedAlgorithm)
                .InvokeCommand(SelectAlgorithm);
        }

        private bool StringMatches(string matching, string filter)
        {
            if (filter != null)
            {
                return matching.ToLower().Contains(filter.ToLower());
            }
            else
            {
                return true;
            }
        }
    }
}