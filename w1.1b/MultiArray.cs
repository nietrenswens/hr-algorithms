using System.Numerics;

namespace ToDo;

public class MultiArray : IMultiArray
{
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        //ToDo
        T[] result = new T[arr2D.GetLength(0)];
        for (int row = 0; row < arr2D.GetLength(0); row++)
        {
            T rowResult = default!;
            for (int col = 0; col < arr2D.GetLength(1); col++)
            {
                rowResult += arr2D[row, col];
            }
            result[row] = rowResult;
        }
        return result;
    }
    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>
    {
        //ToDo
        T[] results = new T[arr2D.GetLength(1)];
        for(int row = 0; row < arr2D.GetLength(0); row++)
        {
            for (int col = 0; col < arr2D.GetLength(1); col++)
            {
                if (results[col] == default) results[col] = arr2D[row, col];
                else results[col] += arr2D[row, col]; 
            }
        }
        return results;
    }

    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>
    {
        T[] sums = GetRowSums(arrJagged);
        int highestIndex = 0;
        T highestResult = default!;
        for (int row = 0; row < arrJagged.Length; row++)
        {
            if (sums[row] > highestResult)
            {
                highestResult = sums[row];
                highestIndex = row;
            }
        }
        return new Tuple<int, T>(highestIndex, highestResult);
    }

    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>
    {
        //ToDo
        // calculate number of cols
        int numberOfCols = calculateNumOfCols(arrJagged);
        T[] sums = new T[numberOfCols];
        for (int i = 0; i < numberOfCols; i++)
        {
            T[] column = getCol(arrJagged, i);
            for (int j = 0; j < column.Length; j++)
            {
                sums[i] += column[j];
            }
        }
        int highestIndex = 0;
        T highestSum = default!;
        for (int sumIndex = 0; sumIndex < sums.Length; sumIndex++)
        {
            if (sums[sumIndex] > highestSum)
            {
                highestIndex = sumIndex;
                highestSum = sums[sumIndex];
            }
        }
        return getCol(arrJagged, highestIndex);
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {        
        //ToDo
        throw new NotImplementedException();
    }

    public static T[,]? Zip<T>(T[] a, T[] b)
    {        
        //ToDo
        throw new NotImplementedException();
    }

    private static T[] getCol<T>(T[][] arrJagged, int colindex)
    {
        T[] columValues = new T[arrJagged.Length];
        int numberOfCols = calculateNumOfCols(arrJagged);
        if (colindex > numberOfCols - 1)
            throw new ArgumentOutOfRangeException();
        for(int row = 0; row < arrJagged.Length; row++)
        {
            for(int col = 0; col < arrJagged[row].Length; row++)
            {
                if (col == colindex)
                    columValues[row] = arrJagged[row][col];
            }
        }
        return columValues;
    }

    private static int calculateNumOfCols<T>(T[][] arrJagged)
    {
        int maxcollength = 0;
        for(int rows = 0; rows < arrJagged.GetLength(0); rows++)
        {
            if (arrJagged[rows].Length > maxcollength) maxcollength = arrJagged[rows].Length;
        }
        return maxcollength;
    }

    private static T[] GetRowSums<T>(T[][] arrJagged) where T : INumber<T>
    {
        T[] sums = new T[arrJagged.GetLength(0)];
        for (int row = 0; row < sums.Length; row++)
        {
            T result = default!;
            for (int col = 0; col < arrJagged[row].Length; col++)
            {
                result += arrJagged[row][col];
            }
            sums[row] = result;
        }
        return sums;
    }
}