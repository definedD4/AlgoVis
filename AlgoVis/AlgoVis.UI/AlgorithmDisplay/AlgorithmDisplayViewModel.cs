using AlgoVis.Core;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmDisplay
{
    public class AlgorithmDisplayViewModel : ReactiveObject
    {
        private readonly CompiledAlgorithm _algorithm;

        public string AlgorithmTitle => _algorithm.Name;

        public AlgorithmDisplayViewModel(CompiledAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }
    }
}