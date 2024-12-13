public abstract class Goal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }  // This exposes the _points field publicly

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}


public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() =>
        $"{Name} - {Description} ({Points} points) - Completed: {_isComplete}";

    public override string GetStringRepresentation() =>
        $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals never complete.
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() =>
        $"{Name} - {Description} ({Points} points) - Never ends.";

    public override string GetStringRepresentation() =>
        $"EternalGoal|{Name}|{Description}|{Points}";
}

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() =>
        $"{Name} - {Description} ({Points} points) - Progress: {_amountCompleted}/{_target} - Bonus: {_bonus}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal|{Name}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
}
