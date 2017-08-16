using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.DataModel
{
    public class OnLocals
    {
        private List<OnLocalUpdateBase> _onLocalUpdateList = new List<OnLocalUpdateBase>();

        internal void FireUpdates()
        {
            foreach (var update in _onLocalUpdateList)
            {
                update.Update();
            }
        }

        public OnLocalUpdate<T> Local<T>(Func<T> selector)
        {
            var onLocal = new OnLocalUpdate<T>(selector);
            _onLocalUpdateList.Add(onLocal);
            return onLocal;
        }
    }
}
