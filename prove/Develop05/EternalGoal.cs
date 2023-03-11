using System;

public class EternalGoal : Goal
{
    private int _numberTimesAccomplished;


    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
    }
    public EternalGoal(string title, string description, int points, int numberTimesAccomplished) : base(title, description, points)
    {
        _numberTimesAccomplished = numberTimesAccomplished;
    }

    public override void DisplayGoal()
    {
        Console.Write("[ ]  ");
        Console.Write($"{_title} ");
        Console.Write($"({_description})");
        Console.Write($"  --  {_points} points");
        Console.WriteLine($"  -- Accomplished: {_numberTimesAccomplished} times");
    }
    public override int RecordEvent()
    {
        Spinner spinner = new Spinner();
        _numberTimesAccomplished ++;
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        spinner.Wait(3);
        return _points;
    }
    public override string SaveGoal()
    {
        return ("EternalGoal" + "~|~" + _title + "~|~" + _description + "~|~" + _points + "~|~" + _numberTimesAccomplished);
    }
}