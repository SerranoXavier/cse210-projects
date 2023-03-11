using System;

public abstract class Goal
{
    private protected string _title;
    private protected string _description;
    private protected int _points;
    private protected bool _isAchieved;
    //add dates start and date end


    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isAchieved = false;
    }
    public Goal(string title, string description, int points, bool isAchieved)
    {
        _title = title;
        _description = description;
        _points = points;
        _isAchieved = isAchieved;
    }

    public abstract void DisplayGoal();
    public abstract int RecordEvent();
    public abstract string SaveGoal();
}