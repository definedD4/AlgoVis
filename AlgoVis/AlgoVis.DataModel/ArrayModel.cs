using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace AlgoVis.DataModel
{
    public class ArrayModel
    {
        public ReactiveList<ItemModel> Items { get; } = new ReactiveList<ItemModel>();

        public void Swap(int item1, int item2)
        {
            var temp = Items[item1];
            Items[item1] = Items[item2];
            Items[item2] = temp;
        }
    }
}
