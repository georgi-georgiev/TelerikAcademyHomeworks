namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Merge(collection, 0, collection.Count - 1);
        }

        public static void Merge(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Merge(collection, left, middle);
                Merge(collection, middle + 1, right);

                T[] leftArray = new T[middle - left + 1];
                T[] rightArray = new T[right - middle];
                
                Array.Copy(collection.ToArray(), left, leftArray, 0, middle - left + 1);
                Array.Copy(collection.ToArray(), middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        collection[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        collection[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i].CompareTo(rightArray[j]) <= 0)
                    {
                        collection[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        collection[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
