using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.UI.Exceptions
{

    [Serializable]
    public class ParamValidationNotPassedException : Exception
    {
        public ParamValidationNotPassedException() { }
        public ParamValidationNotPassedException(string message) : base(message) { }
        public ParamValidationNotPassedException(string message, Exception inner) : base(message, inner) { }
        protected ParamValidationNotPassedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
