using System.Collections;
using System.Runtime.InteropServices;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
        Head = null;
        count = 0;
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        Head = new SingleNode<T>(value, Head);
        count++;
    }

    public void AddLast(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        SingleNode<T>? current = Head;
        if (Head == null)
        {
            Head = new SingleNode<T>(value);
            return;
        }
        while (current?.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
        count++;
    }

    public bool Remove(T value)
    {
        SingleNode<T>? current = Head;
        if(current.Value.CompareTo(value) == 0)
        {
            Head = current.Next;
            return true;
        }
        while (current?.Next != null)
        {
            if(current.Next.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public SingleNode<T>? Search(T value)
    {
        SingleNode<T>? current = Head;
        while (current != null)
        {
            if (current.Value.CompareTo(value) == 0) return current;
            current = current.Next;
        }
        return null;
    }

    public bool Contains(T value) => Search(value) != null;

    public void AddSorted(T value)
    {
        if(Head == null || Head.Value.CompareTo(value) > 0)
        {
            Head = new SingleNode<T>(value, Head);
            count++;
            return;
        }
        SingleNode<T>? current = Head;
        while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
        {
            current = current.Next;
        }
        current.Next = new SingleNode<T>(value, current.Next);
        count++;
    }

    public void Clear()
    {
        Head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}