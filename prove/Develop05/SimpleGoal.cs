using System;

public class SimpleGoal : Goal
{
    private DateTime _dateAccomplished;


    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
    }
    public SimpleGoal(string title, string description, int points, bool isAchieved, DateTime dateAccomplished) : base(title, description, points, isAchieved)
    {
        _dateAccomplished = dateAccomplished;
    }

    public override void DisplayGoal()
    {
        if (_isAchieved)
        {
            Console.Write("[X]  ");
            Console.Write($"{_title} ");
            Console.Write($"({_description})");
            Console.Write($"  --  {_points} points");
            Console.WriteLine($"  -- Accomplished: {_dateAccomplished.ToShortDateString()}");
        }
        else
        {
            Console.Write("[ ]  ");
            Console.Write($"{_title} ");
            Console.Write($"({_description})");
            Console.WriteLine($"  --  {_points} points");
        }
    }
    public override int RecordEvent()
    {
        if (_isAchieved)
        {
            Console.WriteLine("The goal is already completed.");
            return 0;
        }
        else
        {
            Spinner spinner = new Spinner();
            _isAchieved = true;
            _dateAccomplished = DateTime.Now;
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
            spinner.Wait(3);
            return _points;
        }
    }
    public override string SaveGoal()
    {
        return ("SimpleGoal" + "~|~" + _title + "~|~" + _description + "~|~" + _points + "~|~" + _isAchieved + "~|~" + _dateAccomplished);
    }
}