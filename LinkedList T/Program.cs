namespace LinkedList_T
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListT<int> list = new LinkedListT<int>();


            //list.AddSorted("5");
            //list.AddSorted("Hello");
            //list.AddSorted("Hello");
            //list.AddSorted("World");
            //list.AddSorted("PRIVET");
            //list.AddSorted("GB");
            //list.AddSorted("12");
            //list.AddSorted("Hello");
            //list.AddSorted("100");

            //list.RemoveAll("Hello");

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);

            list.Print();
            list.QuickSort();
            list.Print();


        }
    }
}