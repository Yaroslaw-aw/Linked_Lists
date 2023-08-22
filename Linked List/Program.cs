namespace Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Add(6);
            linkedList.Add(7);

            //linkedList.SetValue(5, 888);
            
            linkedList.Print();
            linkedList.Reverce();
            linkedList.Print();

            //Console.WriteLine(linkedList.GetValue(5));

            //Console.WriteLine(linkedList.ListSize());

            //LinkedList newList = linkedList.CopyList();
            //linkedList.RemoveAll(2);
            //linkedList.Print();
            //newList.Print();
        }
    }
}