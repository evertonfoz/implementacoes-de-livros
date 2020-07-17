using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modulo1.HelperControls
{
    public class ListViewGrouping<K, T> : Collection<T>
    {
        public K Key { get; private set; }

        public ListViewGrouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
