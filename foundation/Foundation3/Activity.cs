using System;

abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date} ({Minutes} min): Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km";
    }
}

class Running : Activity
{
    private double _distance; // in kilometers

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed = Distance / Time * 60
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace = Time / Distance
    }
}

class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * Minutes) / 60; // Distance = Speed * Time / 60
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed; // Pace = 60 / Speed
    }
}

class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0; // Distance = Laps * 50m / 1000 (convert to km)
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed = Distance / Time * 60
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace = Time / Distance
    }
}
