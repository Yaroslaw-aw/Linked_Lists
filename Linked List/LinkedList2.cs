namespace Linked_List
{
    internal class LinkedList2
    {
        Node head;
        Node tail;

        public void push(int value)
        {
            Node node = new Node();
            node.value = value;
            node.next = head;
            head.previous = node; 
            head = node;
        }

        /// <summary>
        /// Достает последний элемент
        /// </summary>
        /// <returns></returns>
        public int peek()
        {
            int result = 0; // TODO решить с null (int result = null;)
            if (tail != null)
            {
                result = tail.value;
                tail.previous.next = null;
                tail = tail.previous;
            }
            return result;
        }




        class Node
        {
            public int value;
            public Node next;
            public Node previous;
        }
    }
}
