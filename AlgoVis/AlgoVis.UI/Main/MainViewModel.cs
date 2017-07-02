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
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.UI.Main
{
    public class MainViewModel : ReactiveObject
    {
        [Algorithm("Test", Description = "")]

        public class TestAlgorithm : AlgorithmBase
        {
            public ArrayModel Model { get; }

            public TestAlgorithm()
            {
                Model = new ArrayModel();

                /*Model.Items.AddRange(new int[]
                {
                    1,
                    3,
                    6,
                    2,
                    79
                }.Select(x => new ItemModel(x)));*/
            }

            [Action("Test", "Test")]
            public IEnumerable<IActionStatement> Test()
            {
                Model.Add(new ItemModel(8));
                yield return new WaitStatement(TimeSpan.FromSeconds(0.75d));
                Model.Add(new ItemModel(13));
                yield return null;
            }
        }

        public MainViewModel()
        {
            this.WhenAnyValue(x => x.Algorithm)
                .Where(a => a != null)
                .Select(a => new ArrayDisplay(a.Model, x => new CircleDisplay(x)))
                .ToPropertyEx(this, x => x.Content);

            Algorithm = new TestAlgorithm();

            new AlgorithmExecutor(Dispatcher.CurrentDispatcher).Exectue(Algorithm.Build().Actions.FirstOrDefault(), new object[] {});
        }

        public ArrayDisplay Content { [ObservableAsProperty] get; }
        [Reactive] public TestAlgorithm Algorithm { get; set; }
    }
}
