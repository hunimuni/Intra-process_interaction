using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = { 100_000, 1_000_000, 10_000_000 };

        foreach (int size in sizes)
        {
            int[] array = Enumerable.Range(1, size).ToArray();

            Console.WriteLine($"Array size: {size}");

            MeasureTime("Sequential", () => ArraySumCalculator.SequentialSum(array));
            MeasureTime("Parallel", () => ArraySumCalculator.ParallelSum(array));
            MeasureTime("LINQ Parallel", () => ArraySumCalculator.LinqParallelSum(array));

            Console.WriteLine();
        }
    }

    static void MeasureTime(string methodName, Func<long> sumMethod)
    {
        Stopwatch sw = Stopwatch.StartNew();
        long sum = sumMethod();
        sw.Stop();

        Console.WriteLine($"{methodName}: {sw.ElapsedMilliseconds} ms, Sum: {sum}");
    }
}