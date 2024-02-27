using Solution; 
SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

if(intList != null) {
    intList.AddSorted(5);
    intList.AddSorted(3);
    intList.AddSorted(4);
    foreach(int i in intList)
    {
        System.Console.WriteLine(i);
    }
    
}