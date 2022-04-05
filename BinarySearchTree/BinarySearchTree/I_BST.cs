using DataStructuresCommon;
using System;

namespace BinarySearchTree
{
    // Define a delegate type that will point to a method that
    //will perform some action on a data member of type T
    // during a traversal

    public delegate void ProcessData<T>(T data);
   public enum TRAVERSALORDER { PRE_ORDER, IN_ORDER, POST_ORDER};

    public interface I_BST<T> : I_Collection<T> where T: IComparable<T>
    {
        /// <summary>
        /// Given a data element, find the corresponding elemet of equal value
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// A reference to the ite, if found, else return the default type for T
        /// </returns>
        T Find(T data);

        /// <summary>
        /// Returns the height of the tree
        /// </summary>
        /// <returns>
        /// height of the tree
        /// </returns>
        int Height();

        /// <summary>
        /// Similar to an enumerator to do traversals
        /// Can specify a particular operation with the delegate
        /// </summary>
        /// <param name="pd"> a delegate method</param>
        /// <param name="to"> the desired traversal order</param>
        void Iterate(ProcessData<T> pd, TRAVERSALORDER to);
    }
}
