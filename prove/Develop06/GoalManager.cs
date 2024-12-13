using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        Goal newGoal = choice switch
        {
            1 => new SimpleGoal(name, description, points),
            2 => new EternalGoal(name, description, points),
            3 => CreateChecklistGoal(name, description, points),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        _goals.Add(newGoal);
    }

    private ChecklistGoal CreateChecklistGoal(string name, string description, int points)
    {
        Console.Write("Enter target count: ");
        int target = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter bonus points: ");
        int bonus = int.Parse(Console.ReadLine() ?? "0");

        return new ChecklistGoal(name, description, points, target, bonus);
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Select a goal to record: ");
        int choice = int.Parse(Console.ReadLine() ?? "0") - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _goals[choice].RecordEvent();
            _score += _goals[choice].IsComplete() ? _goals[choice].Points : 0;
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        using StreamWriter writer = new StreamWriter("goals.txt");
        foreach (var goal in _goals)
        {
            writer.WriteLine(goal.GetStringRepresentation());
        }
        writer.WriteLine(_score);
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                        break;
                }
            }
        }
    }
}