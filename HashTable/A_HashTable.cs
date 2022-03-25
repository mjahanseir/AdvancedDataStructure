using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public abstract class A_HashTable<K, V> where K : IComparable<K> where V : IComparable<V>
    {
        // KeyValue <K,v> where K: IComparable<K>,
        //                      V: IComparable<V>

        //  DECLARING
        protected object[] oDataArray;

        protected int iCount;

        protected double dLoadFactor = 0.72;

        protected int iNumberCollisions = 0;

        public int Count { get => iCount; }
        public int NumCollisions { get => iNumberCollisions; }

        public int HTSize
        {
            get
            {
                return oDataArray.Length;
            }
        }

        ////////////////////////////////////////////////////////////////////////

        #region Helpers
        protected int HashFunction(K key)
        {
            return Math.Abs(key.GetHashCode() % HTSize);
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////

        #region   Abstract Methods
        public abstract void Add(K key, V value);
        public abstract V Get(K key);
        public abstract void Remove(K key);
        #endregion  
    }
}
