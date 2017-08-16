using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using AlgoVis.Core.ActionStatements;
using Splat;

namespace AlgoVis.Core
{
    public class AlgorithmExecutor : IEnableLogger
    {
        private readonly Dispatcher _dispatcher;

        public AlgorithmExecutor(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Exectue(ActionExecutePack pack)
        {
            var enumerator = pack.Action.Execute(pack.Parameters.ToArray()).GetEnumerator();

            var executionThread = new Thread(() =>
            {
                using (enumerator)
                {
                    while(true)
                    {
                        bool shouldContinue = false;
                        _dispatcher.Invoke(() =>
                        {
                            shouldContinue = enumerator.MoveNext();
                        });
                        if(!shouldContinue) break;

                        IActionStatement statement = enumerator.Current;
                        if (statement is WaitStatement)
                        {
                            var time = ((WaitStatement) statement).Time;
                            //this.Log().Debug($"Algorithm execution waiting for ${time.TotalSeconds} seconds");
                            //Console.WriteLine($"Algorithm execution waiting for ${time.TotalSeconds} seconds");
                            Thread.Sleep(time);
                        }
                    }
                }
            });

            executionThread.Start();
        }
    }
}
