using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCommon
{
   public abstract class A_Collection<T> : I_Collection<T> where T : IComparable<T>
    {

        #region Abstract Method
        public abstract void Add(T data);
        public abstract void Clear();
        public abstract bool Remove(T data);
        public abstract IEnumerator<T> GetEnumerator();
        #endregion

        public virtual int Count   /////////////////////////// virtual keyword : abstract has to override but VIRTUAL IS OPTIONAL
        {
            get
            {
                int count = 0;
                // the foreach statement works for collections that implement the IEnuramable interface
                // the foreach will automatically call GetEnumerator and the use it to iterable through the collection
                foreach(T item in this)
                {
                    count++;
                }
                return count;
            }
        }
        

        //////////////////////  20220204
        

        ////////////
        
        public bool Contains(T data)
        {
            bool found = false;

            IEnumerator<T> myEnum = GetEnumerator();
            myEnum.Reset();

            while(!found && myEnum.MoveNext())
            {
                found = myEnum.Current.Equals(data);
            }

            return found;
        }




        public override string ToString()                         //////////////////// HAS TO OVERRIDE virual optional override ha to 
        {
            StringBuilder result = new StringBuilder("[");
            string sep = " , ";

            foreach(T item in this)
            {
                result.Append(item + sep);
            }

            if (Count > 0)  // At the end we have , extra and we need to remove extra comma
            {
                result.Remove(result.Length - sep.Length, sep.Length);
            }

            result.Append("]");

            return result.ToString();


        }




        ///<summary>
        ///Call the GetEnumerator that returns a generic enumerator</summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
