using AlgoVis.Core;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmListItem
{
    public class AlgorithmListItemViewModel : ReactiveObject
    {
        public CompiledAlgorithm Algorithm { get; }

        public string DisplayName => Algorithm.Name;

        public AlgorithmListItemViewModel(CompiledAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }
    }
}