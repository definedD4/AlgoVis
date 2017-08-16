using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.DataModel
{
    public interface IModel
    {
        void ResetMetadata();
    }

    public interface IHasArrayMetadata
    {
        IArrayMetadata Metadata { get; }
    }

    public interface IArrayMetadata
    {
        ItemModel this[int index] { get; }
    }
}
