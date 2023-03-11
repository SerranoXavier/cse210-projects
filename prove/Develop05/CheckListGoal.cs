using System;

public class ChecklistGoal : Goal
{
    private int _numberIterationsTotal;
    private int _numberIterationsDone;
    private int _bonus;


    public ChecklistGoal(string title, string description, int points, int numberIterationsTotal, int bonus) : base(title, description, points)
    {
        _numberIterationsTotal = numberIterationsTotal;
        _numberIterationsDone = 0;
        _bonus = bonus;
    }
    public ChecklistGoal(string title, string description, int points, bool isAchieved, int numberIterationsTotal, int numberIterationsDone, int bonus, DateTime dateAccomplished) : base(title, description, points, isAchieved, dateAccomplished)
    {
        _numberIterationsTotal = numberIterationsTotal;
        _numberIterationsDone = numberIterationsDone;
        _bonus = bonus;
    }

    public override void DisplayGoal()
    {
        if (_isAchieved)
        {
            Console.Write("[X]  ");
            Console.Write($"{_title} ");
            Console.Write($"({_description})");
            Console.Write($"  --  {_points} points");
            Console.Write($" + {_bonus} bonus points");
            Console.Write($"  --  completed: {_numberIterationsDone}/{_numberIterationsTotal}");
            Console.WriteLine($"  --  accomplished: {_dateAccomplished.ToShortDateString()}");
        }
        else
        {
            Console.Write("[ ]  ");
            Console.Write($"{_title} ");
            Console.Write($"({_description})");
            Console.Write($"  --  {_points} points");
            Console.Write($" + {_bonus} bonus points");
            Console.WriteLine($"  --  currently completed: {_numberIterationsDone}/{_numberIterationsTotal}");
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
            _numberIterationsDone ++;
            if (_numberIterationsDone < _numberIterationsTotal)
            {
                Console.WriteLine($"Congratulations! You have earned {_points} points!");
                spinner.Wait(3);
                return _points;
            }
            else
            {
                _isAchieved = true;
                _dateAccomplished = DateTime.Now;
                Console.WriteLine($"Congratulations! You have earned {_points + _bonus} points!");
                spinner.Wait(3);
                return (_points + _bonus);
            }
        }
    }
    public override string SaveGoal()
    {
        return ("CheckListGoal" + "~|~" + _title + "~|~" + _description + "~|~" + _points + "~|~" + _isAchieved + "~|~" + _numberIterationsTotal + "~|~" + _numberIterationsDone + "~|~" + _bonus + "~|~" + _dateAccomplished);
    }
}
