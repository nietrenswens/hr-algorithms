int[] Bubble(int[] arr) // Complexity = O(N^2)
{
    bool swapped = true;
    while (swapped)
    {
        swapped = false;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i+1])
            {
                swapped = true;
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }
    }
    return arr;
}

int[] pp = { 1, 5, 4, 2, 3, 9, 6, 7, -4, -2, -4, 100, 5678, 32, 45, 18, -123, -9 };
void PrintArray(int[] arr)
{
    foreach(var v in arr)
    {
        System.Console.Write(v + ", ");
    }
    System.Console.WriteLine();
}

PrintArray(pp);
PrintArray(Bubble(pp));