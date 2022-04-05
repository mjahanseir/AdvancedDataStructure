using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class AVLT<T> : BST<T> where T: IComparable<T>
    {
        #region Balance Method
        /*
          Algorithm:
                 newRoot <-- current Node
                 if current node is not NULL
                        get the height difference --> iHeightDiff :  can be unbalanced R or L
                        if the tree is high-heavy (unbalanced to the right)
                                get heightDiff for right child
                                if right child is left heavy
                                then do DoubleL
                                else do SingleL

                         if the tree is high-heavy (unbalanced to the Left)
                                    get heightDiff for Left child
                                    if Left child is Right heavy
                                    then do DoubleR
                                    else do SingleR
                          return newRoot
                        
         */

        internal override Node<T> Balance(Node<T> nCurrent)
        {

            return null;
        }

        #endregion





        #region Height Balance Methods
        /// <summary>
        /// Detemines the height difference between the L and R child nodes of the Current node
        /// </summary>
        /// <param name="nCurrent"></param>
        /// <returns> Positive = Left heavy , Negative  =  Right heavy</returns>
        /// 
        private int GetHeightDifference(Node<T> nCurrent)
        {
            int iHeightLeft = -1;
            int iHeightRight = -1;
            int iHeightDiff = 0;

            if (nCurrent != null)
            {
                if(nCurrent.Right != null)
                {
                    iHeightRight = RecHeight(nCurrent.Right);  // RecHeight we inherit from last impl.
                }
                if(nCurrent.Left != null)
                {
                    iHeightLeft = RecHeight(nCurrent.Left);  // RecHeight we inherit from last impl.
                }
            }

            iHeightDiff = iHeightLeft - iHeightRight;
            return iHeightDiff;

        }
        #endregion





        #region Rotation Methods

        private Node<T> SingleLeft(Node<T> nOldRoot)
        {
            // Get a refrence to the OldRoot right node. this is the new root.
            Node<T> nNewRoot = nOldRoot.Right;
            // set OldRoot right to point at newRoot Left
            nOldRoot.Right = nNewRoot.Left;
            // set newRoot left to point to OldRoot
            nNewRoot.Left = nOldRoot; 

            return nNewRoot;
        }
        private Node<T> SingleRight(Node<T> nOldRoot)
        {
            Node<T> nNewRoot = nOldRoot.Left;
            // opposite of previous
            nOldRoot.Left = nNewRoot.Right;
            // Same
            nNewRoot.Right = nOldRoot; 

            return nNewRoot;
        }
        private Node<T> DoubleLeft(Node<T> nOldRoot) 
        {
            nOldRoot.Right = SingleRight(nRoot.Right);
            return SingleLeft(nOldRoot);
        }
        private Node<T> DoubleRight(Node<T> nOldRoot)
        {
            nOldRoot.Left = SingleLeft(nRoot.Left);
            return SingleRight(nOldRoot);
        }
        #endregion
    }
}
