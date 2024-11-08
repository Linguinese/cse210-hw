using System;

class Program
{
    static void Main(string[] args)
    {
        int number_guess_number;

        Console.Write("What's the magic number? ");
       string magic_number = Console.ReadLine();
       int number_magic_number = int.Parse(magic_number); 
       do{
            Console.Write("What's your guess? ");
            string guess_number = Console.ReadLine();
            number_guess_number = int.Parse(guess_number); 
            if (number_guess_number > number_magic_number){
                Console.WriteLine("Lower");
            }
            else if (number_guess_number < number_magic_number){
                Console.WriteLine("Higher");
            }

       } while (number_guess_number != number_magic_number);

        Console.WriteLine("Correct");
       
    }
}