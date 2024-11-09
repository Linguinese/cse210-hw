using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a series of numbers (enter 0 to stop):");

        do
        {
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"Sum: {sum}");

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"Average: {average}");

        int max = numbers.Count > 0 ? numbers.Max() : 0;
        Console.WriteLine($"Max: {max}");
    }
}
