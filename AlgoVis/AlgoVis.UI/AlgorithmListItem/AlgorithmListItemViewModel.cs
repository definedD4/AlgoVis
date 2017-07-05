using System;
using System.Reactive;
using System.Reactive.Linq;
using AlgoVis.Core;
using AlgoVis.UI.Messages;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmListItem
{
    public class AlgorithmListItemViewModel : ReactiveObject
    {
        public CompiledAlgorithm Algorithm { get; }

        public string DisplayName => Algorithm.Name;

        public ReactiveCommand<Unit, CompiledAlgorithm> Open { get; }

        public AlgorithmListItemViewModel(CompiledAlgorithm algorithm)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));

            Open = ReactiveCommand.Create(() => Algorithm);

            MessageBus.Current.RegisterMessageSource(Open.Select(a => new OpenAlgorithmMessage(a)));
        }
    }
}