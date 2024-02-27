using Solution; 
DoublyLinkedList<int> dl = new DoublyLinkedList<int>();
dl.AddSorted(5);
dl.AddSorted(3);
dl.AddSorted(4);
dl.AddSorted(8);
var current = dl.First;
while (current != null)
{
    var next = current.Next == null ? "null" : current.Next.Value.ToString();
    Console.WriteLine($"Value: {current.Value}, Next: {next}, Previous: {current.Previous?.Value}");
    current = current.Next;
}
current = dl.Last;
System.Console.WriteLine("Reversed");
while (current != null)
{
    Console.WriteLine($"Value: {current.Value}, Next: {current.Next?.Value}, Previous: {current.Previous?.Value}");
    current = current.Previous;
}

