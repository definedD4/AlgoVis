using System;
using System.Reactive.Linq;
using AlgoVis.Core;
using AlgoVis.UI.AlgorithmDetails;
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

        public AlgorithmDetailsViewModel DetailsViewModel { [ObservableAsProperty] get; }

        public ReactiveCommand Add { get; }

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

            this.WhenAnyValue(x => x.SelectedAlgorithm)
                .Where(vm => vm != null)
                .Select(vm => new AlgorithmDetailsViewModel(vm.Algorithm))
                .ToPropertyEx(this, x => x.DetailsViewModel);

            Add = ReactiveCommand.Create(() => throw new NotImplementedException());
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