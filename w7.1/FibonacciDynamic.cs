
namespace Solution;

public static class DynamicProgramming {

    public static long FibonacciDynamic(long n, long[] storedResults)
    {    
        Utils.ShowCallStack(false); //DO NOT comment this line of code
        if (n < 2) return storedResults[n];
        if (storedResults[n] == 0)
        {
            var res = FibonacciDynamic(n - 1, storedResults) + FibonacciDynamic(n - 2, storedResults); 
            storedResults[n] = res;
        }
        return storedResults[n];
    }
}    
