using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using AlgoVis.Core.ActionStatements;

namespace AlgoVis.Core
{
    public class AlgorithmExecutor
    {
        private readonly Dispatcher _dispatcher;

        public AlgorithmExecutor(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Exectue(IAction action, object[] parameters)
        {
            var enumerator = action.Execute(parameters).GetEnumerator();

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
                            Thread.Sleep(((WaitStatement) statement).Time);
                        }
                    }
                }
            });

            executionThread.Start();
        }
    }
}
