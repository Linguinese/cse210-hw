using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessApp
{
    abstract class MindfulnessActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public MindfulnessActivity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Starting {Name}...\n");
            Console.WriteLine(Description);
            Console.Write("Enter the duration of the activity (in seconds): ");
            Duration = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Prepare to begin...");
            DisplaySpinner(3);
        }

        public virtual void EndActivity()
        {
            Console.WriteLine("\nGood job!");
            Console.WriteLine($"You completed the {Name} activity for {Duration} seconds.");
            DisplaySpinner(3);
        }

        public void DisplaySpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void StartActivity()
        {
            base.StartActivity();
            int cycles = Duration / 6; // Each cycle takes 6 seconds
            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("\nBreathe in...");
                Countdown(3);
                Console.WriteLine("Breathe out...");
                Countdown(3);
            }
            EndActivity();
        }

        private void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class ReflectionActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "What did you learn about yourself through this experience?"
        };

        public ReflectionActivity() : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize your inner power.")
        { }

        public override void StartActivity()
        {
            base.StartActivity();
            Random random = new();
            Console.WriteLine($"\n{Prompts[random.Next(Prompts.Count)]}");
            DisplaySpinner(5);

            int timeRemaining = Duration;
            while (timeRemaining > 0)
            {
                Console.WriteLine($"\n{Questions[random.Next(Questions.Count)]}");
                DisplaySpinner(5);
                timeRemaining -= 5;
            }
            EndActivity();
        }
    }

    class ListingActivity : MindfulnessActivity
    {
        private static readonly List<string> Prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        public override void StartActivity()
        {
            base.StartActivity();
            Random random = new();
            Console.WriteLine($"\n{Prompts[random.Next(Prompts.Count)]}");
            DisplaySpinner(5);

            List<string> items = new();
            int timeElapsed = 0;
            Console.WriteLine("Start listing items:");
            while (timeElapsed < Duration)
            {
                Console.Write("> ");
                string input = Console.ReadLine() ?? "";
                items.Add(input);
                timeElapsed += 2; // Assuming 2 seconds per entry
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
            EndActivity();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness App");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choose an activity: ");

                string choice = Console.ReadLine() ?? "";
                MindfulnessActivity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => null,
                    _ => throw new InvalidOperationException("Invalid choice. Please select a valid option.")
                };

                if (activity == null)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                activity.StartActivity();
            }
        }
    }
}
