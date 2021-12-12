using System.Runtime.CompilerServices;

namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        private readonly Dictionary<Tuple<TKey1,TKey2>,TValue> _data= new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        public int NumberOfElements => _data.Count;
    

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => _data[Tuple.Create<TKey1, TKey2>(key1,key2)]; 
            set => _data[Tuple.Create<TKey1, TKey2>(key1, key2)] = value; 
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
           return this._data.Keys.Where(a => a.Item1.Equals(key1))
                .Select(a => Tuple.Create(a.Item2, _data[a]))
                .ToList();
        }
    

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            var list = new List<Tuple<TKey1,TValue>>();
            foreach (var var in _data)
            {
                if (var.Key.Item2.Equals(key2))
                {
                   list.Add(new Tuple<TKey1, TValue>(var.Key.Item1,var.Value));
                }
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            var list = new List<Tuple<TKey1,TKey2,TValue>>();
            foreach (var var in _data)
            {
                list.Add(new Tuple<TKey1,TKey2,TValue>(var.Key.Item1, var.Key.Item2, var.Value));
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var k1 in keys1)
            {
                foreach (var k2 in keys2)
                {
                    this[k1, k2] = generator(k1, k2);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        protected bool Equals(Map2D<TKey1, TKey2, TValue> other)
        {
            return Equals(_data, other._data);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other is Map2D<TKey1, TKey2, TValue> otherMap2d)
            {
                return this.Equals(otherMap2d);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Map2D<TKey1, TKey2, TValue>) obj);
        }

        public override int GetHashCode()
        {
            return (_data != null ? _data.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", this.GetElements()
                .Select(e => $"({e.Item1}, {e.Item2}) -> {e.Item3} \n")) + "}";
        }
    }
}
