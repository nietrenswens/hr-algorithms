
//-----This file HAS to be modified----

public class Stack<T> : SimpleStack<T>
{
    public Stack() : base(){ }

    public override void Push(T item)
    {
        if(Capacity == top + 1)
        {
            Capacity *= 2;
            T?[] newarr = new T[Capacity];
            for (int i = 0; i < arr.Length; i++)
            {
                newarr[i] = arr[i];
            }
            arr = newarr;
        }
        base.Push(item);
    }

    public override T? Peek()
    {
        if (top == -1)
            throw new StackEmptyException("The Stack is empty.");
        return base.Peek();
    }

    public override T? Pop()
    {
        if (top == -1)
            throw new StackEmptyException("The Stack is empty.");
        return base.Pop();
    }

    
}
