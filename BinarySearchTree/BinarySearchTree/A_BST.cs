using System;
using System.Collections.Generic;
using System.Text;
using DataStructuresCommon;

namespace BinarySearchTree
{
    public abstract class A_BST<T>: A_Collection<T>, I_BST<T> where T : IComparable<T>
    {
        //  20220207 -  

        #region Attributes
        // A reference to the root of the tree
        protected Node<T> nRoot;
        // counter to track the number of items in the tree
        protected int iCount;

        #endregion

        public override int Count
        {
            get
            {
                return iCount;
            }
        }

        #region I_BST methods
        public abstract T Find(T data);
        public abstract int Height();
        public abstract void Iterate(ProcessData<T> pd, TRAVERSALORDER to);
        #endregion

    }
}
