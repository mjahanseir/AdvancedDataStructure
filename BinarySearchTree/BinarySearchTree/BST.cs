using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DataStructuresCommon;

namespace BinarySearchTree
{
    public class BST<T> : A_BST<T>, ICloneable where T : IComparable<T>
    {
        ///<summary>
        ///Constructor
        /// </summary>
        public BST()
        {
            nRoot = null;
            iCount = 0;
        }

        #region Other Functionality
        public T RecFindSmallest(Node<T> nCurrent)
        {
            T tRcturn = default(T);
            if (nCurrent.Left != null)
            {
                tRcturn = RecFindSmallest(nCurrent.Left);
            }
            else
            {
                tRcturn = nCurrent.Data;
            }
            return tRcturn;
        }

        public T RecFindLargest(Node<T> nCurrent)
        {
            T tRcturn = default(T);
            if (nCurrent.Right != null)
            {
                tRcturn = RecFindSmallest(nCurrent.Right);
            }
            else
            {
                tRcturn = nCurrent.Data;
            }
            return tRcturn;
        }


        #endregion

        #region A_BST Implementation
        public override void Add(T data)
        {
            if (nRoot == null)
            {
                nRoot = new Node<T>(data);
            }
            else
            {
                RecAdd(data, nRoot);
                //Balance Here
                nRoot = Balance(nRoot);
            }
            iCount++;
        }

        private void RecAdd(T data, Node<T> nCurrent)
        {
            int iResult = data.CompareTo(nCurrent.Data);

            //Check to see where to insert... L or R
            if (iResult < 0)  // insert L
            {
                if (nCurrent.Left == null)
                {
                    // No left child so insert here
                    nCurrent.Left = new Node<T>(data);
                }
                else
                {
                    // left child so keep going to the left
                    RecAdd(data, nCurrent.Left);

                    //Balance here
                    nCurrent.Left = Balance(nCurrent.Left);
                }
            }
            else
            {
                if (nCurrent.Right == null)
                {
                    nCurrent.Right = new Node<T>(data);
                }
                else
                {
                    RecAdd(data, nCurrent.Right);
                    //Balance here
                    nCurrent.Right = Balance(nCurrent.Right);

                }
            }
        }




        internal virtual Node<T> Balance(Node<T> nCurrent)
        {
            return nCurrent;
        }




        public override void Clear()
        {
            nRoot = null;
            iCount = 0;
        }

        public override T Find(T data)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        public override int Height(){
            int iHeight = -1;
            if (nRoot != null)
            {
                iHeight = RecHeight(nRoot);
            }
            return iHeight;
         }

        public int RecHeight(Node<T> nCurrent)
        {
            int iHeightLeft = 0;
            int iHeightRight = 0;


            //If the current node is a leaf , go to
            // the last line and effectively return 0
            if (!nCurrent.IsLeaf())
            {
                // is there a left subtreee
                if(nCurrent.Left != null)
                {
                    //left height is the height of the subtree +1
                    iHeightLeft = RecHeight(nCurrent.Left) + 1;
                }
                // is there a Right subtreee
                if (nCurrent.Right != null)
                {
                    //Right height is the height of the subtree +1
                    iHeightRight = RecHeight(nCurrent.Right) + 1;
                }

            }

            return iHeightLeft > iHeightRight ? iHeightLeft : iHeightRight;
        }

        public override void Iterate(ProcessData<T> pd, TRAVERSALORDER to)
        {
                if(nRoot != null)
            {
                RecIterate(nRoot, pd, to);
            }
        }
        public  void RecIterate(Node<T> nCurrent, ProcessData<T> pd, TRAVERSALORDER to)
        {
            if (to== TRAVERSALORDER.PRE_ORDER)
            {
                pd(nCurrent.Data);
            }
            if (nCurrent.Left!= null)
            {
                RecIterate(nCurrent.Left, pd, to);
            }
            


            if (to == TRAVERSALORDER.IN_ORDER)
            {
                pd(nCurrent.Data);
            }
            if (nCurrent.Right != null)
            {
                RecIterate(nCurrent.Right, pd, to);
            }


            if (to == TRAVERSALORDER.POST_ORDER)
            {
                pd(nCurrent.Data);
            }
           
        }
        #endregion


        public override bool Remove(T data)
        {

            bool wasRemoved = false;
            nRoot = RecRemove(nRoot, data, ref wasRemoved);
            return wasRemoved;
        }
        private Node<T> RecRemove(Node<T> nCurrent , T data , ref bool wasRemoved)
        {
            T tSubstitute = default(T);
            int iCompare = 0;

            if(nCurrent != null)
            {
                iCompare = data.CompareTo(nCurrent.Data);

                if(iCompare < 0)
                {
                    nCurrent.Left = RecRemove(nCurrent.Left, data, ref wasRemoved);
                }else if (iCompare > 0)
                {
                    nCurrent.Right = RecRemove(nCurrent.Right, data, ref wasRemoved);
                }
                else
                {
                    wasRemoved = true;
                    if(nCurrent.IsLeaf())
                    {
                        iCount--;
                        nCurrent = null;
                    }
                    else
                    {
                        if( nCurrent.Left != null)
                        {
                            tSubstitute = RecFindLargest(nCurrent.Left);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Left = RecRemove(nCurrent.Left, tSubstitute, ref wasRemoved);
                        }
                        else
                        {
                            tSubstitute = RecFindLargest(nCurrent.Right);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Right = RecRemove(nCurrent.Right, tSubstitute, ref wasRemoved);
                        }
                    }
                }

            }
            return nCurrent;
        }

        #region IClonable Placeholder
        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Enumerator Implementation
        private class DepthFirstEnumerator : IEnumerator<T>
        {
            private BST<T> parent = null;
            private Node<T> nCurrent = null;

            private Stack<Node<T>> sNodes;

            public DepthFirstEnumerator(BST<T> parent)
            {
                this.parent = parent;
                Reset();

            }

            public T Current => nCurrent.Data;
            object IEnumerator.Current => nCurrent.Data;

            public void Reset()
            {
                sNodes = new Stack<Node<T>>();
                if (parent.nRoot != null)
                {
                    sNodes.Push(parent.nRoot);
                }
                nCurrent = null;
            }
            public void Dispose()
            {
                parent = null;
                nCurrent = null;
                sNodes = null;
            }
            public bool MoveNext()
            {
                bool bMoved = false;
                if(sNodes.Count > 0)
                {
                    bMoved = true;
                    nCurrent = sNodes.Pop();
                    if(nCurrent.Right != null)
                    {
                        sNodes.Push(nCurrent.Right);
                    } 
                    if(nCurrent.Left != null)
                    {
                        sNodes.Push(nCurrent.Left);
                    }
                }
                return bMoved;
            }
        }
        #endregion


    }
}
