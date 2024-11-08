using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your first name?");
        string first_name = Console.ReadLine();
        Console.Write("What's your last name?");
        string last_name = Console.ReadLine();
        Console.WriteLine($"Your Name is {last_name}, {first_name} {last_name}");
        
    }
}