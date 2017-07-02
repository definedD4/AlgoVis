using AlgoVis.Core;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmListItem
{
    public class AlgorithmListItemViewModel : ReactiveObject
    {
        private readonly CompiledAlgorithm _algorithm;

        public AlgorithmListItemViewModel(CompiledAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public string DisplayName => _algorithm.Name;
    }
}