using System;
using AlgoVis.Core;

namespace AlgoVis.UI.Messages
{
    public class OpenAlgorithmMessage : MessageBase
    {
        public OpenAlgorithmMessage(CompiledAlgorithm algorithm)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
        }

        public CompiledAlgorithm Algorithm { get; }

        public override string ToString()
        {
            return $"[OpenAlgorithmMessage {Algorithm.Name}]";
        }
    }
}