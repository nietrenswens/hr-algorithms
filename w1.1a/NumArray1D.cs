using System.Numerics;

namespace ToDo;
public class NumArray1D<T> : Array1D<T>, INumArray1D<T> where T : IComparable<T>, INumber<T>
{
    public NumArray1D(int size = 10):base(size) {  }
    public NumArray1D(T[] data):base(data) { }
  
    public T? Aggregate(Func<T, T, T> fx)
    {
        T result = default!;
        for (int i = 0; i < _data.Length; i++)
        {
            result = fx(result, _data[i]);
        }
        return result;
    }

    public T? Max()
    {
        return Aggregate((T a, T b) => a > b ? a : b);
    }

    public T? Min()
    {
        return Aggregate((T a, T b) => a < b ? a : b);
    }

    public T? Product(bool IgnoreZeros = true)
    {
        if (IgnoreZeros)
            return Aggregate((T a, T b) => {
                if (a.Equals(default)) return b;
                if (b.Equals(default)) return a;
                return a * b;
            });
        return Aggregate((T a, T b) => a * b);
            
    }

    public T? Sum()
    {
        //ToDo
        return Aggregate((T a, T b) => a + b);
    }
}