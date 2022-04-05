using System;
using DataStructuresCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
   public abstract class A_LinkedList<T> : A_Collection<T>, I_LinkedList<T> where T : IComparable<T>
    {
        
        public abstract void Insert(int index, T data);
        public abstract T DeleteAt(int index);
       

        public T GetItemAt(int index)
        {
            // counter to keep track of number of items
            int counter = 0;

            //variable to store data 
            T data = default(T);
            if(index<0 || index>counter)
            {
                throw new IndexOutOfRangeException("Invalid");
            }
           IEnumerator<T> enumerator = this.GetEnumerator();
            enumerator.Reset();
            while(enumerator.MoveNext() && counter != index)
            {
                counter++;  
            }    
            data = enumerator.Current;  
;
            return data;
        }
       
        public int IndexOf(T data)
        {
            int index = 0;
            IEnumerator<T> enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current.CompareTo(data)==0)
                {
                    index++;
                  
                }
            }
            return index;

            return -1;  
        }

    }
}
