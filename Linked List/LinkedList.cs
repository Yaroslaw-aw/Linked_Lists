using System.Diagnostics;
using System.Numerics;

namespace Linked_List
{
    internal class LinkedList
    {
        Node root;
        int size;
        public int Size { get { return size; } }

        /// <summary>
        /// Add element to list
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
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

        public void Push(int value)
        {
            Node node = new Node(value);
            node.next = root;
            root = node;
            size++;
        }

        /// <summary>
        /// Достает первый элемент
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            int result = 0; // TODO решить с null (int result = null;)
            if (root != null)
            {
                result = root.value;
                root = root.next;
            }
            return result;
        }


            /// <summary>
            /// Remove by value
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool Remove(int value)
            {
                if (root == null)
                    return false;

                if (root.value == value)
                {
                    root = root.next;
                    size--;
                    return true;
                }

                Node currentNode = root;
                while (currentNode.next != null)
                {
                    if (currentNode.next.value == value)
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
            /// </summary>
            /// <param name="value"></param>
            public int RemoveAll(int value)
            {
                int prevSize = size;
                while (root != null && root.value == value)
                {
                    root = root.next;
                    size--;
                }
                if (root == null)
                    return prevSize - size;

                Node currentNode = root;
                while (currentNode.next != null)
                {
                    if (currentNode.next.value == value)
                    {
                        currentNode.next = currentNode.next.next;
                        size--;
                    }
                    else
                        currentNode = currentNode.next;
                }
                return prevSize - size;
            }

            public void Revert()
            {
                if (root != null && root.next != null)
                {
                    // Node temp = root;
                    Revert(root.next, root);
                    // temp.next = null;
                }
            }

            void Revert(Node currentNode, Node previousNode)
            {
                if (currentNode == null)
                {
                    root = currentNode;
                }
                else
                {
                    Revert(currentNode.next, currentNode);
                }
                currentNode.next = previousNode;
                previousNode.next = null;
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


            /// <summary>
            /// Get value of node by index
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public int GetValue(int index)
            {
                return this.GetNode(index).value;
            }


            /// <summary>
            /// Change value of element by index
            /// </summary>
            /// <param name="index"></param>
            /// <param name="value"></param>
            public void SetValue(int index, int value)
            {
                this.GetNode(index).value = value;
            }


            public void Reverce()
            {
                if (root == null)
                    return;

                int pivot = 0;

                if (size % 2 == 0)
                    pivot = size / 2 - 1;
                else
                    pivot = size / 2;

                for (int i = 0; i < pivot; i++)
                {
                    SwapValue(i, size - i - 1);
                }
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
                int temp = node1.value;
                node1.value = node2.value;
                node2.value = temp;
            }


            /// <summary>
            /// Return the copy of List
            /// </summary>
            /// <returns></returns>
            public LinkedList CopyList()
            {
                LinkedList copyList = new LinkedList();
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
        private class Node
        {
            public int value;
            public Node next;
            public Node() { }
            public Node(int value) { this.value = value; }
        }
    }
}
