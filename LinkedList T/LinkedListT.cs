using System.Collections;
using System.Collections.Generic;

namespace LinkedList_T
{
    internal class LinkedListT<T> : Comparer<T> where T : IComparer /*IComparer*/  // TODO Решить вопрос с компоратором
    {
        Node root;
        int size;
        public int Size { get { return size; } }

        /// <summary>
        /// Add element to list
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (root == null)
            {
                this.root = new Node(value);
                size = 1;
                return;
            }

            Node currentNode = root;
            while (currentNode.next != null)
                currentNode = currentNode.next;
            currentNode.next = new Node(value);
            size++;
        }

        public void AddSorted(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                size = 1;
                return;
            }
            if (Compare(root.value, value) > 0)
            {
                Node newNode = new Node(value);                
                newNode.next = root;
                root = newNode;
                size++;
                return;
                
            }
            Node currentNode = root;
            while (currentNode.next != null)
            {
                if (Compare(currentNode.next.value, value) > 0)
                {
                    Node newNode = new Node(value);
                    newNode.next = currentNode.next;
                    currentNode.next = newNode;
                    size++;
                    return;
                }
                currentNode = currentNode.next;
            }
            currentNode.next = new Node(value);
            size++;
        }


        //public override int Compare(T? x, T? y)
        //{
        //    return Compare(x, y);
        //}

        //int Compare(int x, int y)
        //{
        //    if (x > y) return 1;
        //    if (x < y) return -1;
        //    else return 0;
        //}

        /// <summary>
        /// Remove by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            if (root == null)
                return false;

            if (Compare(root.value, value) == 0)
            {
                root = root.next;
                size--;
                return true;
            }

            Node currentNode = root;
            while (currentNode.next != null)
            {
                if (Compare(currentNode.next.value, value) == 0)
                {
                    currentNode.next = currentNode.next.next;
                    size--;
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }


        /// <summary>
        /// Remove by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                root = root.next;
                size--;
                return;
            }
            Node preDeleted = this.GetNode(index - 1);
            preDeleted.next = preDeleted.next.next;
            size--;
        }


        /// <summary>
        /// Remove all Nodes with Node.value = value
        /// and return the count of removes
        /// </summary>
        /// <param name="value"></param>
        public int RemoveAll(T value)
        {
            int prevSize = size;
            while (root != null && Compare(root.value, value) == 0)
            {
                root = root.next;
                size--;
            }
            if (root == null)
                return prevSize - size;

            Node currentNode = root;
            while (currentNode.next != null)
            {
                if (Compare(currentNode.next.value, value) == 0)
                {
                    currentNode.next = currentNode.next.next;
                    size--;
                }
                else
                    currentNode = currentNode.next;
            }
            return prevSize - size;
        }


        /// <summary>
        /// Clear List
        /// </summary>
        public void Clear()
        {
            root = null;
            size = 0;
        }


        /// <summary>
        /// Get Node by Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        Node GetNode(int index)
        {
            if (root == null)
                return null;
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            Node currentNode = root;
            for (int i = 0; i < index; i++)
                currentNode = currentNode.next;
            return currentNode;
        }

        public void QuickSort()
        {
            QuickSort(0, size - 1);
        }

        private void QuickSort(int leftBorder, int rightBorder)
        {
            int leftMarker = leftBorder;
            int rightMarker = rightBorder;
            T pivot = this.GetValue((leftMarker + rightMarker) / 2);
            while (leftMarker <= rightMarker)
            {
                while (Compare(this.GetValue(leftMarker), pivot) < 0)
                {
                    leftMarker++;
                }
                while (Compare(this.GetValue(rightMarker), pivot) > 0)
                {
                    rightMarker--;
                }
                if (leftMarker <= rightMarker)
                    if (leftMarker < rightMarker)
                        SwapValue(leftMarker, rightMarker);
                leftMarker++;
                rightMarker--;
            }
            if (leftMarker < rightBorder)
                QuickSort(leftMarker, rightBorder);
            if (leftBorder < rightMarker)
                QuickSort(leftBorder, rightMarker);
        }




        /// <summary>
        /// Get value of node by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetValue(int index)
        {
            return this.GetNode(index).value;
        }


        /// <summary>
        /// Change value of element by index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetValue(int index, T value)
        {
            this.GetNode(index).value = value;
        }


        /// <summary>
        /// Swap Values of Node's.value
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void SwapValue(int index1, int index2)
        {
            if (index1 == index2)
                return;
            if (index1 < 0 || index1 >= size || index1 < 0 || index2 >= size)
                return;

            Node node1 = null, node2 = null, currentNode = root;
            for (int i = 0; currentNode != null; i++)
            {
                if (index1 == i)
                {
                    node1 = currentNode;
                }
                else if (index2 == i)
                {
                    node2 = currentNode;
                }
                if (node2 != null && node1 != null)
                    break;
                currentNode = currentNode.next;
            }
            T temp = node1.value;
            node1.value = node2.value;
            node2.value = temp;
        }


        /// <summary>
        /// Return the copy of List
        /// </summary>
        /// <returns></returns>
        public LinkedListT<T> CopyList()
        {
            LinkedListT<T> copyList = new LinkedListT<T>();
            Node currentNode = root;
            while (currentNode != null)
            {
                copyList.Add(currentNode.value);
                currentNode = currentNode.next;
            }
            return copyList;
        }


        public int ListSize()
        {
            return size;
        }


        /// <summary>
        /// Print all list
        /// </summary>
        public void Print()
        {
            Console.Write("[ ");
            Node currentNode = this.root;
            while (currentNode != null)
            {
                Console.Write(currentNode.value + " ");
                currentNode = currentNode.next;
            }
            Console.WriteLine("] size: " + size);
        }


        //public override int Compare(T? x, T? y)
        //{
        //    throw new NotImplementedException();
        //}

        private class Node
        {
            public T value;
            public Node next;
            public Node() { }
            public Node(T value) { this.value = value; }
        }
    }
}

