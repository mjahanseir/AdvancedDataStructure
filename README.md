# Data Structure
- Tree
  - Binary Search Tree
  - AVL
- Linked List
- Hash Table


### BST
Create a C# interface for the binary tree ADT:
As with other ADTs, create() will produce a binary tree root which by definition will be empty; isEmpty() returns whether or not the tree contains any nodes; the three following methods are traversals, inorder(), preorder() and postorder() - we will visit these traversals when we implement the code; search() returns true or false depending on whether or not the element exists; delete() removes the node containing the element.
The C# signatures for a binary tree implementation will include:

    public class BinTree<T> where T : IComparable<T> {
      T dataElement; // data element being stored at the root node
      BinTree<T> leftBT; // left subtree root if != null
      BinTree<T> rightBT; // right subtree root if != null
      BinTree<T> myParent; // for practical purposes, store a reference to my parent
      public BinTree() {....}
      public BinTree(BinTree<T> inParent) {...}
      private void SetParent(BinTree<T> inParent)  {...}
      public boolean IsEmpty() {...}
      public void Insert(T inVal) {...}
      public boolean Search(T searchVal)  {...}
      public void Delete(T searchVal)  {...}
      public void Inorder()  {...}
      public void Preorder()  {...}
      public void Postorder()  {...}
    }
    
    ### AVL
A balanced ordered binary tree is called an AVL tree (named after inventors Adelson-Velsky and Landis). To create and maintain an AVL tree, we need to monitor the height in each subtree. If during insert, or deletion, the difference between the height on the left and the the height on the right is greater than one, the tree is unbalanced and will not perform efficiently during searches. When an AVL tree becomes unbalanced, it must be re-balanced to maintain its efficiency. Re-balancing is not terribly complex but very important to searching.
For our algorithms (insert and delete) to maintain a balanced tree, we need to add to each node a balance factor representing the difference of the balance factors of the subtrees below it. The balance factor of a node N (root of a subtree) is the height difference of the left subtree and the right subtree:
          BalanceFactor(N) = Height(RightSubtree(N)) – Height(LeftSubtree(N))
A binary tree is defined to be an AVL tree if the invariant BalanceFactor(N) ∈ {–1,0,+1} holds for every node N in the tree. Otherwise the node and its subtrees represent a tree that is unbalanced.
A node N with BalanceFactor(N) < 0 is called "left-heavy", one with BalanceFactor(N) > 0 is called "right-heavy", and one with BalanceFactor(N) = 0 is sometimes simply called "balanced".
      we consider the AVL balanced if the node N and its subtrees has a balance factor of 0 +/- 1. 
So, to implement a balanced binary tree we can extend the ordered binary tree ADT by adding a height factor (integer) and override the insert and delete methods to maintain the height factor at the node. We may introduce a heightFactor calculation routine that visits each node in the tree and updates the heightFactor, as well as a new methods to rebalance the tree at node N when N's balance factor > 1 or < -1.
