using System.Security.AccessControl;

namespace ToDo;
public class Sort<T> : ISort<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        bool swapped = true;
        while (swapped)
        {
            swapped = false;
            for(int i = 0; i < data.Length - 1; i++)
            {
                if (data[i].CompareTo(data[i+1]) == 1)
                {
                    (data[i], data[i + 1]) = (data[i + 1], data[i]);
                    swapped = true;
                }
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for(int i = 1; i < data.Length; ++i)
        {
            T key = data[i];
            int j = i - 1;
            while (j >= 0 && data[j].CompareTo(key) == 1)
            {
                data[j + 1] = data[j];
                j = j - 1;
            }
            data[j + 1] = key;
        }
    }


    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            int middle = (low + high) / 2;
            MergeSort(array, low, middle);
            MergeSort(array, middle + 1, high);
            Merge(array, low, middle, high);
        }
    }

    public static void Merge(T[] array, int low, int middle, int high)
    {
        int leftArraySize = middle - low + 1;
        int rightArraySize = high - middle;
        T[] leftArray = new T[leftArraySize];
        T[] rightArray = new T[rightArraySize];

        for (int i = 0; i < leftArraySize; ++i)
            leftArray[i] = array[low + i];
        for (int j = 0; j < rightArraySize; ++j)
            rightArray[j] = array[middle + 1 + j];
        int leftIndex = 0, rightIndex = 0;
        int mergedIndex = low;
        while (leftIndex < leftArraySize && rightIndex < rightArraySize)
        {
            if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
            {
                array[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                array[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }

        // Copy remaining elements of leftArray[], if any
        while (leftIndex < leftArraySize)
        {
            array[mergedIndex] = leftArray[leftIndex];
            leftIndex++;
            mergedIndex++;
        }

        // Copy remaining elements of rightArray[], if any
        while (rightIndex < rightArraySize)
        {
            array[mergedIndex] = rightArray[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
    }
}