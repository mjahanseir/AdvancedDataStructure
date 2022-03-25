using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public abstract class A_OpenAddressing<K, V>: A_HashTable<K,V> where K : IComparable<K> where V : IComparable<V>
    {
        protected abstract int GetIncrement(int iAttempt, K key);

        private PrimeNumber pn = new PrimeNumber();
        public A_OpenAddressing()
        {
            oDataArray = new object[pn.GetNextPrime()];
        }
        public override void Add(K key, V value)
        {
            //////////////////    Number of attempt for increment calculation
            int iAttempt = 1;
            //////////////////    Initial hash to location in the table
            int iInitialHash = HashFunction(key);

            /////////////////     our current Location as we traverse the table
            int iCurrentLocation = iInitialHash;

            /////////////////      Create an object from the key and value to eventually 
            /////////////////      to insert into the Hash as keyValue object
            KeyValue<K, V> kvNew = new KeyValue<K, V>(key, value);
            int iPositionToAdd = -1;

            //find an empty location to add the current item
            while(oDataArray[iCurrentLocation]!= null)
            {
                // is it a keyvalue
                if (oDataArray[iCurrentLocation].GetType() == typeof(KeyValue<K, V>))
                {
                    KeyValue<K, V> kv = (KeyValue<K, V>)oDataArray[iCurrentLocation];
                    if (kv.Equals(kvNew))
                    {
                        throw new ApplicationException("Item already exists");
                    }
                }
                else
                {
                    if (iPositionToAdd == -1)
                    {
                        iPositionToAdd = iCurrentLocation;
                    }
                }

                // increament our location
                iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                /////////////////////   adjust if location with increament 

                iCurrentLocation %= HTSize;

                iNumberCollisions++;

            }// END OF WHILE

            if (iPositionToAdd == -1)
            {
                iPositionToAdd = iCurrentLocation;
            }
            oDataArray[iPositionToAdd] = kvNew;
            iCount++;

            //check if the table is overloadded
            if (IsOverloaded())
            {
                ExpandHashTable();
            }
        }

        private bool IsOverloaded()
        {
            return iCount/ (double)HTSize > dLoadFactor;
        }
        private void ExpandHashTable()
        {
            object[] oOldArray = oDataArray;

            oDataArray = new object[pn.GetNextPrime()];

            iCount = 0;
            iNumberCollisions = 0;

            for(int i=0; i<oOldArray.Length; i++)
            {
                if(oOldArray[i] != null)
                {
                    if(oOldArray[i].GetType() == typeof(KeyValue<K, V>))
                    {
                        KeyValue<K, V> kv = (KeyValue<K, V>)oOldArray[i];
                        this.Add(kv.Key, kv.Value);
                    }
                }
            }
        }


        public override V Get(K key)
        {
            V vReturn = default(V);
            int iInitialHash = HashFunction(key);
            int iCurrentLocation = iInitialHash;

            int iAttempt = 1;
            bool found = false;

            //////////////////    Check the table and if we have  not found ehat we want
            //////////////////    but there's something in the location we're looking at
            while(!found && oDataArray[iCurrentLocation] != null)
            {
                //////////////////    is it a keyvalue object, not a tombstone
                if (oDataArray[iCurrentLocation].GetType() == typeof(KeyValue<K, V>))
                {
                    //////////////////    is it the keyvalue object we're looking for
                    KeyValue<K, V> kv = (KeyValue<K, V>)oDataArray[iCurrentLocation];
                    if(kv.Key.CompareTo(key) == 0)
                    {
                        //////////////////    found so set our return variable to the value
                        vReturn = kv.Value;
                        //////////////////    and set our flag
                        found = true;
                    }
                }
                //////////////////   update the current location to look at regardless of the loop
                ///// ////////////   the loop could have passed or failed... if it passed and we
                //////////////////   found something, the while loop exits here. if not, we've
                //////////////////  update currentlocation for the next loop iteration 

                iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                iCurrentLocation %= HTSize;
            }

            if (!found)
            {
                throw new ApplicationException("Key does not exist in table");
            }
            return vReturn;

        }


        public override void Remove(K key)
        {
            int iInitialHash = HashFunction(key);
            int iCurrentLocation = iInitialHash;
            int iAttempt = 1;
            bool found = false;
        }

    }
}
