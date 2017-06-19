using System;

namespace AlgoVis.Core.ActionStatements
{
    public sealed class WaitStatement : IActionStatement
    {
        public WaitStatement(TimeSpan time)
        {
            Time = time;
        }

        public TimeSpan Time { get; }
    }
}