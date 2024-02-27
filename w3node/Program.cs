
public class Program
{
    public static void Main()
    {
        TestLinkedList();
    }

    private static void TestLinkedList()
    {
        LinkList linkList = new();
        linkList.AddHead(1);
        linkList.AddHead(2);
        linkList.AddHead(3);
        linkList.AddHead(4);
        linkList.Display();
        linkList.RemoveHead();
        linkList.RemoveHead();
        linkList.Display();
    }
}

public class Node {
    public int Data;
    public Node? Next;

    public Node(int data, Node? next)
    {
        this.Data = data;
        this.Next = next;
    }

}

public class LinkList
{
    Node? Start = null;
    public void AddHead(int data)
    {
        Start = new Node(data, Start);
    }
    
    public void RemoveHead()
    {
        Start = Start?.Next;
    }

    public void Display()
    {
        var current = Start;
        while (current != null)
        {
            System.Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}

interface Stack
{
    void Push(int data);
    int Pop();
    int Peek();
    bool IsEmpty();
    bool IsFull();
}

public class MyStack : Stack
{
    int[] Array;
    int Top;
    public MyStack(ushort size = 3)
    {
        Array = new int[size];
        Top = -1;
    }
    public bool IsEmpty() => Top == -1;

    public bool IsFull() => Top == Array.Length - 1;

    public int Peek()
    {
        if (IsEmpty())
            throw new Exception("Stack is empty");
        return Array[Top];
    }

    public int Pop()
    {
        if (IsEmpty())
            throw new Exception("Stack is empty");
        return Array[Top--];
    }

    public void Push(int data)
    {
        if (IsFull()) Resize();
        Array[++Top] = data;
    }

    public void Resize()
    {
        int[] newArr = new int[Array.Length + 1];
        for (int i = 0; i < Array.Length; i++)
        {
            newArr[i] = Array[i];
        }
        Array = newArr;
    }
}