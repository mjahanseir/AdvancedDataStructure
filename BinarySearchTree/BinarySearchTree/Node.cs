using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Node<T> where T : IComparable<T>
    {
        #region Attribute
        private T tData;
        private Node<T> nLeft;
        private Node<T> nRight;
        #endregion

        #region Constrauctor
        public Node() : this(default(T), null, null) { }
        public Node(T tData) : this(tData, null, null) { }
        public Node(T tData, Node<T> nLeft, Node<T> nRight)
        {
            this.tData = tData;
            this.nLeft = nLeft;
            this.nRight = nRight;
        }

        #endregion

        #region Properties
        public T Data { get => tData; set => tData = value; }
        public Node<T> Left { get => nLeft; set => nLeft = value; }
        public Node<T> Right { get => nRight; set => nRight = value; }
        #endregion
        #region Other Functionality
        public bool IsLeaf()
        {
            return this.Left == null && this.Right == null;
        }
        #endregion


    }

}
