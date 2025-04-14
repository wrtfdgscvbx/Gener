using System;
using System.Collections.Generic;
using System.Linq;

public class PrimeNumbers
{

    public static IEnumerable<int> GetPrimes(int limit)
    {
        if (limit < 2)
            yield break;

        yield return 2;


        for (int number = 3; number <= limit; number += 2)
        {
            if (IsPrime(number))
            {
                yield return number;
            }
        }
    }


    public static IEnumerable<int> GetAllPrimes()
    {
        yield return 2;

        int number = 3;
        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }
            number += 2;
        }
    }


    public static IEnumerable<int> SkipPrimes(int count)
    {
        return GetAllPrimes().Skip(count);
    }


    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number % 2 == 0) return number == 2;

        int boundary = (int)Math.Sqrt(number);

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Демонстрация работы генератора простых чисел:");


        Console.WriteLine("\nПростые числа до 50:");
        foreach (var prime in PrimeNumbers.GetPrimes(50))
        {
            Console.Write(prime + " ");
        }


        Console.WriteLine("\n\nПервые 20 простых чисел:");
        int count = 0;
        foreach (var prime in PrimeNumbers.GetAllPrimes())
        {
            Console.Write(prime + " ");
            count++;
            if (count >= 20) break;
        }


        Console.WriteLine("\n\nПростые числа после пропуска первых 10:");
        foreach (var prime in PrimeNumbers.SkipPrimes(10).Take(10))
        {
            Console.Write(prime + " ");
        }


        Console.WriteLine("\n\n10 простых чисел после 100-го простого числа:");
        var primesAfter100 = PrimeNumbers.SkipPrimes(100).Take(10);
        foreach (var prime in primesAfter100)
        {
            Console.Write(prime + " ");
        }
    }
}