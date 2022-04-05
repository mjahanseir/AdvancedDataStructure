
using System;
using DataStructuresCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public interface  I_LinkedList<T> : I_Collection<T> where T : IComparable<T>
    {

        public  T GetItemAt(int index);
        public  int IndexOf(T data);
        public  void Insert(int index, T data);
        public T DeleteAt(int index);
    }
}
