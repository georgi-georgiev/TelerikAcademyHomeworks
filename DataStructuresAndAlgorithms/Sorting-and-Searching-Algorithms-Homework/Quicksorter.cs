namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count-1);
        }

        public void QuickSort(IList<T> collection, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int i = left;
            int j = right;
            T p = collection[right];

            while (i < j)
            {
                while (i < j && collection[i].CompareTo(p) <= 0)
                {
                    i++;
                }

                while (i < j && collection[j].CompareTo(p) >= 0)
                {
                    j--;
                }

                if (i < j)
                {
                    T temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;

                }
            }
            T t = collection[i];
            collection[i] = collection[right];
            collection[right] = t;

            QuickSort(collection, left, i - 1);
            QuickSort(collection, i + 1, right);
        }
    }
}
