using System;
using System.Reactive;
using System.Reactive.Linq;
using AlgoVis.Core;
using AlgoVis.UI.Messages;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmDetails
{
    public class AlgorithmDetailsViewModel : ReactiveObject
    {
        private readonly CompiledAlgorithm _algorithm;

        public AlgorithmDetailsViewModel(CompiledAlgorithm algorithm)
        {
            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));

            Open = ReactiveCommand.Create(() => _algorithm);

            MessageBus.Current.RegisterMessageSource(Open.Select(x => new OpenAlgorithmMessage(x)));
        }

        public string Name => _algorithm.Name;

        public string Description => _algorithm.Description;

        public ReactiveCommand<Unit, CompiledAlgorithm> Open { get; }
    }
}