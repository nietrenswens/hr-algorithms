using System.Collections.ObjectModel;

namespace Solution;

public class HashTable<K, V> : IHashTable<K, V>
{
    Entry<K, V>[]? buckets { get; set;}

    public ReadOnlyCollection<Entry<K, V>> data => buckets == null? null : buckets.AsReadOnly();

    public HashTable() { buckets = null; }

    public HashTable(Entry<K, V>[]? input) { importData(input);}

    public HashTable(int capacity)
    {
        buckets = new Entry<K, V>[capacity];
    }

    protected int getIndex(K key)
    {
        int hash = getHashKey(key) % buckets.Length;
        int index = hash;
        bool first_scan = true;
        // While we have not encountered an empty slot and have not found the key
        while (buckets[index] != null && !buckets[index].Key!.Equals(key))
        {
            // Go to the next slot
            index = (index + 1) % buckets.Length;
            // If we have scanned the entire table and returned to the original slot, exit
            if (index == hash && !first_scan)
                return -1;
            first_scan = false;
        }
        // If we have found an empty slot, the key does not exist
        if (buckets[index] == null) return -1;
        return index;
    }

    public bool Add(K key, V value)
    {
        int hash = getHashKey(key) % buckets.Length;
        int index = hash;
        bool first_scan = true;
        // While we have not found an empty slot
        while (buckets[index] != null)
        {
            // If the key already exists
            if (buckets[index].Key!.Equals(key))
                return false;
            // Move to the next slot
            index = (index + 1) % buckets.Length;
            // If we have scanned the entire table and returned to the original slot, exit
            if (index == hash && !first_scan)
                return false;
            first_scan = false;
        }
        // Add the key-value pair to the table
        buckets[index] = new Entry<K,V>(key, value);
        return true;
    }

    public V? Find(K key)
    {
        int index = getIndex(key);
        if (index == -1) return default;
        return buckets[index].Value;
    }

    public bool Delete(K key)
    {
        int index = getIndex(key);
        if (index == -1) return false;
        buckets[index] = default;
        return true;
    }

    private int getHashKey(K key)
    {
        return Math.Abs(key.GetHashCode()); ;
    }


    //DO NOT REMOVE the following method:
    private void importData(Entry<K, V>[]? inputData){
        if(inputData != null) {
            buckets = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i) 
                buckets[i] = inputData[i];
        }
    }
}

