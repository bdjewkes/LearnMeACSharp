using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;



namespace LearnMeACSharp
{
    public class MyList<T>// : System.Collections.Generic.IList<T>
    {
        public class Node
        {
            public Node next;
            public T value;
            public Node(T v)
            {
                this.value = v;
            }
            public Node(Node n, T v)
            {
                this.next = n;
                this.value = v;
            }
        }
        public Node firstnode;

        public MyList() // default constructor
        {
            firstnode = null;
        }
        
           
        public void Add(T item)
        {
            if (firstnode == null) firstnode = new Node(item);
            else
            {
                Node current = firstnode;
                while (current.next != null) current = current.next;
                current.next = new Node(item);
            }
        }
        public int IndexOf(T item)
        {
            Node current = firstnode;
            int index = 0;
            while (current.next != null)
            {
                if ((object)current.value == (object)item) return index;
                else
                {
                    current = current.next;
                    index++;
                }

            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            int i = 0;
            Node current = firstnode;
            while (i < index) { current = current.next; i++; }
            current.next = new Node(current.next, item);
        }

        public void RemoveAt(int index)
        {
            int i = 0;
            Node current = firstnode;
            while (i < index - 1) { current = current.next; i++; }
            Node removed = current.next;
            current.next = removed.next;
            removed = null;

        }

        public T this[int index]
        {
            get
            {
                Node current = firstnode;
                int i=0;
                while (i < index) { current = current.next; i++; }
                return current.value;

            }
            set
            {
                Node current = firstnode;
                int i = 0;
                while (i < index) { current = current.next; i++; }
                current.value = value;
            }
        }

        
        public void Clear()
        {
            this.firstnode = null;
        }

        public bool Contains(T item)
        {
            Node current = firstnode;
            while (current.next != null)
            {
                if ((object)current.value == (object)item) return true;
                else
                {
                    current = current.next;
                }

            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node current = firstnode;
            int index = 0;
            while (current.next != null)
            {
                array[index+arrayIndex]=current.value;
            }
        }

        public int Count
        {
            get
            {
                Node current = firstnode;
                int index = 0;
                while (current.next != null) index++;
                return index + 1;
     
            }
        }

        public bool IsReadOnly
        {
            get{
                return false;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
  /*      public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)new MyListEnumerator<T>(this);
        }

        private class MyListEnumerator<T> : IEnumerator<T>
        {
            private MyList<T> t;
            private int position = -1;
            private Node currentnode;
            public MyListEnumerator(MyList<T> t)
            {
                this.t = t;
                currentnode = t.firstnode;
            }
            public bool MoveNext()
            {
                if (currentnode == null)
                    return false;
                else
                {
                    position++;
                    currentnode = currentnode.next;
                    return true;
                }
            }
            public T Current
            {
                get
                { return currentnode }
            }
            
        }    */
    }
}
