using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.UI.Exceptions
{
    [Serializable]
    public class ParamTypeNotSupportedException : Exception
    {
        public ParamTypeNotSupportedException() { }
        public ParamTypeNotSupportedException(string message) : base(message) { }
        public ParamTypeNotSupportedException(string message, Exception inner) : base(message, inner) { }
        protected ParamTypeNotSupportedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
