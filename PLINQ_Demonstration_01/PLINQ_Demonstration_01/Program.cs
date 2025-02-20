using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace PLINQ_Demonstration_02
{
    class Program
    {
        // IsPrime returns true if number is Prime, else false.
        private static bool IsPrime(int number)
        {
            bool result = true;

            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
            {
                if (number % divisor == 0)
                {
                    result = false;
                }
            }

            return result;
        }
        private static List<int> GetPrimeList(List<int> numbers) => numbers.Where(IsPrime).ToList();

        private static List<int> GetPrimeListWithParallel(List<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }

        static void Main(string[] args)
        {
            int limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForEach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallel = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop total prime numbers: {primeNumbersFromForEach.Count} Time Taken : {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Parallel foreach loop total prime numbers: {primeNumbersFromParallel.Count} Time Taken : {watchForParallel.ElapsedMilliseconds} ms");
        }
    }
}
