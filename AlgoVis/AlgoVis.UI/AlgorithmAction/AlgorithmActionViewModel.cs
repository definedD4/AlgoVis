using System;
using AlgoVis.Core;
using ReactiveUI;
using AlgoVis.UI.AlgorithmActionParam;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace AlgoVis.UI.AlgorithmAction
{
    public class AlgorithmActionViewModel : ReactiveObject
    {
        private readonly IAction _action;

        public string Name => _action.Name;

        public string Description => _action.Description;

        public IReactiveCollection<AlgorithmActionParamViewModel> Parameters { get; }

        public ReactiveCommand<Unit, ActionExecutePack> Execute { get; }

        public AlgorithmActionViewModel(IAction action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));

            Parameters = _action.Parameters
                .CreateDerivedCollection(param => new AlgorithmActionParamViewModel(param));

            var canExecute = Parameters.Count() == 0 
                ? Observable.Return(true) 
                : Parameters
                .Select(p => p.ValidObservable)
                .CombineLatest()
                .Select(v => v.All(x => x))
                .Do(x => Console.WriteLine($"{Name}: can execute = {x}"));

            Execute = ReactiveCommand.Create(() => new ActionExecutePack(_action, Parameters.Select(p => p.Value).ToArray()), canExecute);
        }
    }
}
