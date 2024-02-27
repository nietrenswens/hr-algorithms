using System.Collections;

namespace Solution;

public class DoublyLinkedList<T> : IDoublyLinkedList<T> where T : IComparable<T>
{
    public DoubleNode<T>? First, Last;
    public DoublyLinkedList() => First = Last = null;
    public void Clear() => First = Last = null;

    //Search
    public DoubleNode<T>? Search(T value)
    {
        DoubleNode<T>? current = First;
        if (current == null) return null;
        while (current.Next != null)
        {
            if (current.Value.CompareTo(value) == 0)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    #region "addNode=> first, last, sorted" 
    public void AddFirst(T value)
    {
        if (First == null)
        {
            First = Last = new DoubleNode<T>(value);
        }
        else
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            newNode.Next = First;
            First.Previous = newNode;
            First = newNode;
        }
    }

    public void AddLast(T value)
    {
        if (Last == null)
        {
            Last = First = new DoubleNode<T>(value);
        }
        else
        {
            DoubleNode<T> newNode = new DoubleNode<T>(value);
            newNode.Previous = Last;
            Last.Next = newNode;
            Last = newNode;
        }
    }

    public void AddSorted(T value)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(value);
        if (First == null)
        {
            First = Last = newNode;
            return;
        }
        if (First?.Value.CompareTo(value) > 0)
        {
            First.Previous = newNode;
            newNode.Next = First;
            First = newNode;
            return;
        }
        DoubleNode<T>? current = First;
        while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        else {
            Last = newNode;
        }
        current.Next = newNode;
        newNode.Previous = current;
    }
    #endregion

    public bool Remove(T value)
    {
        DoubleNode<T>? current = First;
        if (First == null) return false;
        if (First.Value.CompareTo(value) == 0)
        {
            First = First.Next;
            return true;
        }
        while (current?.Next != null)
        {
            if (current.Next.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Delete(DoubleNode<T> node)
    {
        // check Prev
        // check Next
        // check First
        // check Last
        throw new NotImplementedException();
     
    }

    public IEnumerator<T> GetEnumerator()
    {
        DoubleNode<T>? current = First;
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
