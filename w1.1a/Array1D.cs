namespace ToDo;
public class Array1D<T> : IArray1D<T> where T : IEquatable<T>
{
    protected T[] _data=null!;
    protected int _index;
   
    public Array1D(int size = 10) { 
        _data = new T[size];
        _index = 0;
    }

    public Array1D(T[] data) { 
        //Shallow or deep copy here
        _data = data; //Shallow copy
        _index = data.Length;
    }

    public int Length => //ToDo
        _data.Length;

    public int Count => //ToDo
        _data.Count();

    public int Find(T Item, int startIndex = 0)
    {
        //ToDo
        for (int i = startIndex; i < Length; i++)
        {
            if (_data[i] == null) continue;
            if (_data[i].Equals(Item))
            {
                return i;
            }
        }
        return -1;
    }
}