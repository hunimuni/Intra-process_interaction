using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

class ArraySumCalculator
{
    public static long SequentialSum(int[] array)
    {
        return array.Sum(x => (long)x);
    }

    public static long ParallelSum(int[] array)
    {
        long sum = 0;
        object lockObj = new object();

        Parallel.ForEach(array, (num) =>
        {
            lock (lockObj)
            {
                sum += num;
            }
        });

        return sum;
    }

    public static long LinqParallelSum(int[] array)
    {
        return array.AsParallel().Sum(x => (long)x);
    }
}