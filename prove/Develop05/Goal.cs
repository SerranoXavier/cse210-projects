using System;

public abstract class Goal
{
    private protected string _title;
    private protected string _description;
    private protected int _points;
    private protected bool _isAchieved;
    private protected DateTime _dateAccomplished;


    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isAchieved = false;
    }
    public Goal(string title, string description, int points, bool isAchieved, DateTime dateAccomplished)
    {
        _title = title;
        _description = description;
        _points = points;
        _isAchieved = isAchieved;
        _dateAccomplished = dateAccomplished;
    }

    public abstract void DisplayGoal();
    public abstract int RecordEvent();
    public abstract string SaveGoal();
}