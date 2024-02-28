namespace Solution
{
    public class Stack<T> : IStack<T>
{
    private T[] array;
    private int top; // Represents the index of the top element
    private int size; // Represents the maximum size of the stack

    public Stack(int maxSize = 4)
    {
        if (maxSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxSize), "Size must be greater than zero.");
        }

        array = new T[maxSize];
        top = -1;
        size = maxSize;
    }

    public void Push(T item)
    {
        if (Full)
        {
            Resize(); 
        }
        
        array[++top] = item;
    }

    private void Resize()
    {
        T[] newArray = new T[size * 2];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
        size *= 2;
    }

    public T? Pop()
    {
        if (Empty)
        {
            return default(T);
        }

        T poppedItem = array[top];
        array[top--] = default(T); // Reset the top element
        return poppedItem;
    }

    public T? Peek()
    {
        if (Empty)
        {
            return default(T);
        }

        return array[top];
    }

    public bool Empty => top == -1;

    public bool Full => top == size - 1;

    public int Count => top + 1;

    public int Size => size;
    }
}