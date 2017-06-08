using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.AlgorithmConstruction
{
    [Serializable]
    public class AlgorithmBuildException : Exception
    {
        public AlgorithmBuildException()
        {
        }

        public AlgorithmBuildException(string message) : base(message)
        {
        }

        public AlgorithmBuildException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AlgorithmBuildException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
