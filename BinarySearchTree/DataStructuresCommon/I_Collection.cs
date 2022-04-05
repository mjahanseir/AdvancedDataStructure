using System;
using System.Collections.Generic;

namespace DataStructuresCommon
{
   public interface I_Collection<T> : IEnumerable <T> where T : IComparable<T>
    {
        /// <summary>
        /// Adds given data to the colloction
        /// </summary>
        /// <param name="data"> Item to add </param>

        void Add(T data);

        /// <summary>
        /// Remove the first instance if it exists
        /// </summary>
        /// <param name="data">Item to remove </param>
        /// <return> True if removed, otherwise false</return>

        bool Remove(T data);

        /// <summary>
        /// Determines if an element is in the collection or not
        /// </summary>
        /// <param name="data">Data item to look for </param>
        /// <return> True if found, otherwise false</return>

        bool Contains(T data);

        /// <summary>
        /// Determines if this data structure is equal to another instance
        /// </summary>
        /// <param name="other">The passed in data structure to compare to the calling instance </param>
        /// <return> True if equal, otherwise false</return>

        bool Equals(object other);

        /// <summary>
        /// Remove All items from the current structure
        /// </summary>

        void Clear();

        /// <summary>
        /// A property used to access the number of element in the collection
        /// A property is similar to getter/setter
        /// </summary>
       
        int Count
        {
            get;
        }


    }
}
