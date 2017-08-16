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
        private ReactiveList<ItemModel> _items = new ReactiveList<ItemModel>();
        private List<int> _indices = new List<int>();

        public IReadOnlyReactiveCollection<ItemModel> Items => _items;

        public ItemModel this[int index] => _items[_indices[index]];

        public void Add(ItemModel item)
        {
            item.Index = _items.Count;
            _items.Add(item);
            _indices.Add(item.Index);
        }

        public void Insert(int index, ItemModel item)
        {
            _indices.Insert(index, _items.Count);

            foreach (var it in _items.Where(it => it.Index >= index))
            {
                it.Index++;
            }

            _items.Add(item);
            item.Index = index;
        }

        public void Swap(int item1, int item2)
        {
            int tempIdx = this[item1].Index;
            this[item1].Index = this[item2].Index;
            this[item2].Index = tempIdx;

            tempIdx = _indices[item1];
            _indices[item1] = _indices[item2];
            _indices[item2] = tempIdx;
        }

        public void Clear()
        {
            _items.Clear();
            _indices.Clear();
        }
    }
}
