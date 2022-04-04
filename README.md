# Data Structure
- Tree
  - Binary Search Tree
  - AVL
- Hash Table
- Linked List


<hr>



## BST
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
    

<hr>


## AVL
A balanced ordered binary tree is called an AVL tree (named after inventors Adelson-Velsky and Landis). To create and maintain an AVL tree, we need to monitor the height in each subtree. If during insert, or deletion, the difference between the height on the left and the the height on the right is greater than one, the tree is unbalanced and will not perform efficiently during searches. When an AVL tree becomes unbalanced, it must be re-balanced to maintain its efficiency. Re-balancing is not terribly complex but very important to searching.
For our algorithms (insert and delete) to maintain a balanced tree, we need to add to each node a balance factor representing the difference of the balance factors of the subtrees below it. The balance factor of a node N (root of a subtree) is the height difference of the left subtree and the right subtree:
            BalanceFactor(N) = Height(RightSubtree(N)) – Height(LeftSubtree(N))
A binary tree is defined to be an AVL tree if the invariant BalanceFactor(N) ∈ {–1,0,+1} holds for every node N in the tree. Otherwise the node and its subtrees represent a tree that is unbalanced.
A node N with BalanceFactor(N) < 0 is called "left-heavy", one with BalanceFactor(N) > 0 is called "right-heavy", and one with BalanceFactor(N) = 0 is sometimes simply called "balanced".
      we consider the AVL balanced if the node N and its subtrees has a balance factor of 0 +/- 1. 
So, to implement a balanced binary tree we can extend the ordered binary tree ADT by adding a height factor (integer) and override the insert and delete methods to maintain the height factor at the node. We may introduce a heightFactor calculation routine that visits each node in the tree and updates the heightFactor, as well as a new methods to rebalance the tree at node N when N's balance factor > 1 or < -1.

<hr>

## Hash Table
When calculating locations to insert data, it is inevitable that the same location will result more than once. This is referred to as a collision. Two ways to resolve collisions in hash tables are :
        Separate Chaining
        Open Addressing
## Separate Chaining
With separate chaining, we don't store data directly in the hash table but, rather, the table locations store references to a secondary structure like an arraylist. Data then gets stored in the secondary structure. The way this works is that if a data value hashes to the same location as a previous value, it is added to the arraylist referenced at that location. In the following diagram, 'Dave' was inserted in the first location and, later, 'Joe' hashed to the same location and is added to the same arraylist.
### Open Addressing
With Open Addressing, we store data values directly in the hash table. To resolve collisions, we calculate alternate locations if a collision occurs. For example, consider the above example:
          0	Dave
          1	
          2	Bob
          3	
          4	
          5	
Now Joe hashes to the same location as Dave. With open addressing, we will calculate an increment to use from the original location to an alternate. Its important that this process is also deterministic as the hashing function is. Three types of open addressing are:
          Linear Probing
          Quadratic Probing
          Double Hashing
          Linear Probing

Linear Probing works using a linear equation. We will generally use the number of attempts as part of the equation but that will simply be something like
          linear hash(k) = hash(k) + attemptNum

In the above example, we would simply add 1 to the original hash location for Joe and place that string in cell 1. While this method is simple, it has a serious problem. It tends to cause clustering itself which is precisely what we want to avoid.

- Quadratic Probing
Quadratic Probing is similar except we use some form of quadratic equation which will generally involve the number of attempts but this time we will square that value. Placed into a quadratic equation, we might use something like:

        quadratic hash(k) = hash(k) + c1attemptNum + c2attemptNum2  
        where c1 and c2 are coefficients set to some value between 0 and 1.

Quadratic Probing will tend to produce greater increments for attempts >1, thereby spreading results out more and helping to reduce clustering.

- Double Hashing
With double hashing, the important idea is that the hash value is used to calculate the increment. Because this will not be a simple sequence of values, it is expected that the increments will be more like random values producing better spread and distribution. Examples of double hash are:

          double hash = hash1(k) + hash2(k) 
          where hash2(k) is a separate function such as

          (1+hash1(k)) mod (table size - 1) * attemptNum

          PRIME - (hash1(k) % PRIME)        
          where PRIME is the largest prime number smaller than the current table size.

- Deleting when using Open Addressing

There is an important issue to be aware of when using open addressing: how to handle deleted items. If we clear the spot where the item had been, any following Get operations can potentially fail because the initial Add for those items might have 'bounced' on that location and had to increment a second time to another location. Its important that these calculations remain deterministic even after deletions occur. The solution to this is to replace the deleted item with a placeholder that is neither a data value or an open location. This way, calculations for Get operations can still 'bounce' off of these in the same way as when the item was initially added.

<hr>


## Linked List

The linked list ADT is a very useful structure for many applications. It is more powerful than an array in C# because it can grow dynamically. Since an array is a fixed-size structure (it is fixed to whatever size you used to create it) it is rather inflexible for applications where the collection will grow or shrink frequently over time. A linked list on the other hand, stores two pieces of data for each element being stored: the element itself, and a link to the next element in the list. The component of the list that stores these data is often called a node. The link is represented in pictorial form as an arrow when in fact it is a reference to the next node. 
