using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    public class LinkedList<T> : A_LinkedList<T>, ICloneable where T : IComparable<T>
    {

        private Node<T> header;


        //Constructor 
        public LinkedList()
        {
            header = null;
        }


        #region ICloneable Placeholder
        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Enumerator Implementation

        //enumerator
        public override IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
         private class Enumerator : IEnumerator<T>
        {
            //A reference to the linked list
            private LinkedList<T> parent;
            //A reference to the current node we are visiting
            private Node<T> lastVisited;
            //The next node we want to visit
            private Node<T> nextToVisit;

            public Enumerator(LinkedList<T> parent)
            {
                this.parent = parent;
                Reset();
            }
            public T Current
            {
                get
                {
                    return lastVisited.data;
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return lastVisited.data;
                }
            }
            
            //empty enumerator here setting null
            public void Dispose()
            {

               this. parent = null;
               this.lastVisited = null;
                this. nextToVisit= null;

            }
            // find next node using enumerator
            public bool MoveNext()
            {
                bool flag = false;

                if (nextToVisit != null)
                {
                    flag= true;
                    lastVisited= nextToVisit;
                    nextToVisit = nextToVisit.next;
                }
                return flag;

            }
            //reset enumeration
            public void Reset()
            {
                this.lastVisited = null;
               nextToVisit = parent.header;

            }
        }

        #endregion


        #region A_LinkedList Implementation
        public override void Insert(int index, T data)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index not in range");
            }

            /*  else
               //{
                   //Node<T>currentNode=header;  
                 //  for(int i = 0; i < index; i++)
                   {
                       currentNode=currentNode.next;   
                       Node<T> newNode=currentNode.next;
                       currentNode.next=new Node<T>(data);
                       currentNode.next.next=newNode;  
                   }
               }   */
            else
            {
                RecInsert(index, header, data);
            }


        }
        private void RecInsert(int index, Node<T> current, T data)
        {
            if (index == 0)
            {
                Node<T> newNode = new Node<T>(data, current);
                current = newNode;
            }
            else
            {
                RecInsert(--index, current.next, data);
            }


        }

        public override T DeleteAt(int index)
        {

            Node<T> currentNode = this.header;
            T value = default(T);
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            else if (index == 0)
            {
                header = currentNode.next;
                value = currentNode.data;
                return value;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    currentNode = currentNode.next;
                value = currentNode.next.data;
                currentNode.next = currentNode.next.next;
            }
            return value;
        }

        #endregion


        #region LinkedList Other Methods
        public override void Add(T data)
        {
            if (header == null)
            {
                header=new Node<T>(data);
            }
            else
            {
                RecAdd(data,header);
            }
        }

        private void RecAdd(T data, Node<T> current)
        {
         
            if (current.next == null)
            {
                current = new Node<T>(data);
            }
            else
            {
                RecAdd(data, current.next);
            }
        }
        public override void Clear()
        {
            this.header = null;
        }

        public override bool Remove(T data)
        {
            return RecRemove(ref header,data);
        }
        private bool RecRemove(ref Node<T> current,T data)
        {
             bool flag = false;
          if((current!= null  && current.data.CompareTo(data)==0))
          {
            flag = true;
            current=current.next;
           }
        else
        {
                   flag=RecRemove(ref current.next, data);
         }
            return flag;
        }

        #endregion


        #region Node
        private class Node<T> where T : IComparable<T>
        {
            public T data;
            public Node<T> next;

            public Node() : this(default(T), null) { }
            public Node(T data) : this(data, null) { }
            public Node(T data, Node<T> next)
            {
                this.data = data;
                this.next = next;
            }


        }
        #endregion


       


    }
}
