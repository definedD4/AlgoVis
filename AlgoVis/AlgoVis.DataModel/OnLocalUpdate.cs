using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.DataModel
{
    public abstract class OnLocalUpdateBase
    {
        public abstract void Update();
    }

    public class OnLocalUpdate<T> : OnLocalUpdateBase
    {
        private readonly Func<T> _selector;
        private readonly List<Action<T>> _updates = new List<Action<T>>();
        
        public OnLocalUpdate(Func<T> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            _selector = selector;
        }

        public override void Update()
        {
            foreach (var action in _updates)
            {
                action(_selector());
            }
        }

        public OnLocalUpdate<T> UpdateMetadata(IHasArrayMetadata meta, Action<IArrayMetadata, T> updater)
        {
            _updates.Add(x => updater(meta.Metadata, x));
            return this;
        }
    }
}
