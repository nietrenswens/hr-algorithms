public class Program
{
    public static void Main()
    {
        System.Console.WriteLine(FibonacciRec(10));
    }

    static int Fibonacci(int n)
    {
        if (n < 2) return n;
        int fp = 0, fc = 1;
        for (int i = 2; i <= n; i++)
        {
            int newF = fp+fc;
            fp = fc;
            fc = newF;   
        }
        return fc;
    }

    static int FibonacciRec(int n)
    {
        if (n<2) return n;
        return FibonacciRec(n-1) + FibonacciRec(n-2);
    }
}