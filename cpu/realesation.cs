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
        int workerCount = Environment.ProcessorCount;
        long[] partialSums = new long[workerCount];
        int arrayLength = array.Length;
        int chunkSize = (int)Math.Ceiling((double)arrayLength / workerCount);

        Parallel.For(0, workerCount, i =>
        {
            int start = i * chunkSize;
            int end = Math.Min(start + chunkSize, arrayLength);
            
            long sum = 0;

            for (int j = start; j < end; j++)
            {
                sum += array[j];
            }

            partialSums[i] = sum;
        });

        return partialSums.Sum();
    }

    public static long LinqParallelSum(int[] array)
    {
        return array.AsParallel().Sum(x => (long)x);
    }
}