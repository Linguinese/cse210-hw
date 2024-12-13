using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    goalManager.DisplayPlayerInfo();
                    break;
                case "2":
                    goalManager.ListGoalNames();
                    break;
                case "3":
                    goalManager.CreateGoal();
                    break;
                case "4":
                    goalManager.RecordEvent();
                    break;
                case "5":
                    goalManager.SaveGoals();
                    break;
                case "6":
                    goalManager.LoadGoals();
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
