public class Program
{
    public static void Main()
    {

    }
}

public class KV<K,V>
{
    public K Key { get; set; }
    public V Value { get; set; }
    
}

// Add(K,V)
// Remove(K)
// Find(K)
interface IHT<K,V>
{
    bool Add(K key, V value);
    bool Remove(K key);
    V? Find(K key);
}


public class HT<K,V> : IHT<K,V>
{
    public KV<K, V>[] HTArray;

    public HT(ushort size = 4)
    {
        HTArray = new KV<K, V>[size];
    }

    public bool Add(K key, V value)
    {
        throw new NotImplementedException();
    }

    public V? Find(K key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(K key)
    {
        throw new NotImplementedException();
    }
}