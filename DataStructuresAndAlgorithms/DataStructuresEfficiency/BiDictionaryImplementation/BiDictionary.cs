using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

namespace BiDictionaryImplementation
{
    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private class Entry : IEquatable<Entry>
        {
            public TKey1 KeyOne { get; private set; }
            public TKey2 KeyTwo { get; private set; }
            public TValue Value { get; private set; }

            public Entry(TKey1 key1, TKey2 key2, TValue value)
            {
                this.KeyOne = key1;
                this.KeyTwo = key2;
                this.Value = value;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Entry);
            }

            public bool Equals(Entry other)
            {
                return other != null &&
                    this.KeyOne.Equals(other.KeyOne) &&
                    this.KeyTwo.Equals(other.KeyTwo) &&
                    this.Value.Equals(other.Value);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 0;

                    hashCode = (hashCode * 397) ^ this.KeyOne.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.KeyTwo.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Value.GetHashCode();

                    return hashCode;
                }
            }
        }

        private readonly MultiDictionary<TKey1, Entry> KeyOne = null;
        private readonly MultiDictionary<TKey2, Entry> KeyTwo = null;
        private readonly MultiDictionary<Tuple<TKey1, TKey2>, Entry> TwoKeys = null;

        public BiDictionary(bool allowDuplications)
        {
            this.KeyOne = new MultiDictionary<TKey1, Entry>(allowDuplications);
            this.KeyTwo = new MultiDictionary<TKey2, Entry>(allowDuplications);
            this.TwoKeys = new MultiDictionary<Tuple<TKey1, TKey2>, Entry>(allowDuplications);
        }

        public int Count
        {
            get
            {
                Debug.Assert(KeyOne.KeyValuePairs.Count == TwoKeys.KeyValuePairs.Count && KeyTwo.KeyValuePairs.Count == TwoKeys.KeyValuePairs.Count);

                return this.TwoKeys.KeyValuePairs.Count;
            }
        }

        public void Add(TKey1 keyOne, TKey2 keyTwo, TValue value)
        {
            var entry = new Entry(keyOne, keyTwo, value);

            this.KeyOne.Add(keyOne, entry);
            this.KeyTwo.Add(keyTwo, entry);

            var KeyOneKeyTwo = new Tuple<TKey1, TKey2>(keyOne, keyTwo);
            this.TwoKeys.Add(KeyOneKeyTwo, entry);
        }

        public ICollection<TValue> GetByFirstKey(TKey1 keyOne)
        {
            return this.KeyOne[keyOne].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstKey(TKey1 keyOne)
        {
            var entries = this.KeyOne[keyOne];

            foreach (var entry in entries)
            {
                this.KeyTwo.Remove(entry.KeyTwo, entry);

                var KeyOneKeyTwo = new Tuple<TKey1, TKey2>(entry.KeyOne, entry.KeyTwo);
                this.TwoKeys.Remove(KeyOneKeyTwo, entry);
            }

            this.KeyOne.Remove(keyOne);
        }

        public ICollection<TValue> GetBySecondKey(TKey2 keyTwo)
        {
            return this.KeyTwo[keyTwo].Select(entry => entry.Value).ToArray();
        }

        public void RemoveBySecondKey(TKey2 keyTwo)
        {
            var entries = this.KeyTwo[keyTwo];

            foreach (var entry in entries)
            {
                this.KeyOne.Remove(entry.KeyOne, entry);

                var KeyOneKeyTwo = new Tuple<TKey1, TKey2>(entry.KeyOne, entry.KeyTwo);
                this.TwoKeys.Remove(KeyOneKeyTwo, entry);
            }

            this.KeyTwo.Remove(keyTwo);
        }

        public ICollection<TValue> GetByFirstAndSecondKey(TKey1 keyOne, TKey2 keyTwo)
        {
            var KeyOneKeyTwo = new Tuple<TKey1, TKey2>(keyOne, keyTwo);

            return this.TwoKeys[KeyOneKeyTwo].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstAndSecondKey(TKey1 keyOne, TKey2 keyTwo)
        {
            var KeyOneKeyTwo = new Tuple<TKey1, TKey2>(keyOne, keyTwo);
            var entries = this.TwoKeys[KeyOneKeyTwo];

            foreach (var entry in entries)
            {
                this.KeyOne.Remove(entry.KeyOne, entry);
                this.KeyTwo.Remove(entry.KeyTwo, entry);
            }

            this.TwoKeys.Remove(KeyOneKeyTwo);
        }
    }
}
