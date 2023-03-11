using System;

public class Progress
{
    private List<Goal> _goals;
    private int _totalPoints;
    public int TotalPoints
    {
        get => _totalPoints;
        set => _totalPoints = value;
    }



    public Progress()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }
    public Progress(List<Goal> goals, int totalPoints)
    {
        _goals = goals;
        _totalPoints = totalPoints;
    }

    private int GetValidNumber(string prompt)
    {
        int number;
        Spinner spinner = new Spinner();
        do
        {
            Console.Write($"{prompt} ");
            string input = Console.ReadLine();
            if(int.TryParse(input, out number)) // test if input can be parse as an integer
            {
                if (int.Parse(input) > 0)
                {
                    number = int.Parse(input);
                }
                else{
                    Console.WriteLine("This is not a valid number.");
                    spinner.Wait(2);
                }
            }
            else
            {
                Console.WriteLine("This is not a valid number.");
                spinner.Wait(2);
            }
        } while (number <= 0);
        return number;
    }
    public void DisplayPoints()
    {
        Console.WriteLine($"You have a total of {_totalPoints} points.");
    }
    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("Goals");
        Console.WriteLine();
        if (NumberGoals() == 0)
        {
            Spinner spinner = new Spinner();
            Console.WriteLine("There is no goals.");
            spinner.Wait(3);
        }
        else
        {
            int count = 1;
            foreach (Goal goal in _goals)
            {
                Console.Write($"{count} - ");
                goal.DisplayGoal();
                count ++;
            }
            Console.WriteLine();
            DisplayPoints();
        }
    }
    public int NumberGoals()
    {
        return _goals.Count();
    }
    public void AddGoal(string type)
    {
        switch(type)
        {
            case "SimpleGoal":
            {
                Console.Clear();
                Console.WriteLine("Create a Simple Goal");
                Console.WriteLine();

                Console.Write("What is the Goal? ");
                string title = Console.ReadLine();

                Console.Write("Write a short description of the goal: ");
                string description = Console.ReadLine();

                int points = GetValidNumber("What is the amount of points associated with the goal?");

                SimpleGoal simpleGoal = new SimpleGoal(title, description, points);
                _goals.Add(simpleGoal);
            }
            break;
            case "EternalGoal":
            {
                Console.Clear();
                Console.WriteLine("Create an Eternal Goal");
                Console.WriteLine();

                Console.Write("What is the Goal? ");
                string title = Console.ReadLine();

                Console.Write("Write a short description of the goal: ");
                string description = Console.ReadLine();

                int points = GetValidNumber("What is the amount of points associated with the goal?");

                EternalGoal eternalGoal = new EternalGoal(title, description, points);
                _goals.Add(eternalGoal);
            }
            break;
            case "ChecklistGoal":
            {
                Console.Clear();
                Console.WriteLine("Create a Checklist Goal");
                Console.WriteLine();

                Console.Write("What is the Goal? ");
                string title = Console.ReadLine();

                Console.Write("Write a short description of the goal: ");
                string description = Console.ReadLine();

                int points = GetValidNumber("What is the amount of points associated with the goal?");

                int iterations = GetValidNumber("How many times do you want to accomplish the goal?");

                int bonus = GetValidNumber("What is the amount of bonus points for entirely accomplishing the goal?");

                ChecklistGoal checklistGoal = new ChecklistGoal(title, description, points, iterations, bonus);
                _goals.Add(checklistGoal);
            }
            break;
        }
    }
    public void SaveProgress()
    {
        if (NumberGoals() == 0) // Check if _goals empty
        {
            Spinner spinner = new Spinner();
            Console.WriteLine("There is no goals.");
            spinner.Wait(2);
        }
        else
        {
            // Ask for the file name
            Console.Write("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();

            // Write the points and the goals into a file
            using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt"))
            {
                outputFile.WriteLine(_totalPoints);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.SaveGoal());
                }
            }
        }

    }
    public void LoadFile()
    {
        // Ask for the file name
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        // Read the file
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int count = 0;
        foreach (string line in lines)
        {
            // first line is the number of points
            if (count == 0)
            {
                _totalPoints = int.Parse(line);
            }
            // the other lines are the goals
            else
            {
                string[] parts = line.Split("~|~");
                if (parts[0] == "SimpleGoal")
                {
                    string titleSG = parts[1];
                    string descriptionSG = parts[2];
                    int pointsSG = int.Parse(parts[3]);
                    bool isAchievedSG = bool.Parse(parts[4]);
                    DateTime dateAccomplishedSG = DateTime.Parse(parts[5]);
                    SimpleGoal simpleGoal = new SimpleGoal(titleSG, descriptionSG, pointsSG, isAchievedSG, dateAccomplishedSG);
                    _goals.Add(simpleGoal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    string titleEG = parts[1];
                    string descriptionEG = parts[2];
                    int pointsEG = int.Parse(parts[3]);
                    int numberTimesAccomplishedEG = int.Parse(parts[4]);
                    EternalGoal eternalGoal = new EternalGoal(titleEG, descriptionEG, pointsEG, numberTimesAccomplishedEG);
                    _goals.Add(eternalGoal);
                }
                else if (parts[0] == "CheckListGoal")
                {
                    string titleCLG = parts[1];
                    string descriptionCLG = parts[2];
                    int pointsCLG = int.Parse(parts[3]);
                    bool isAchievedCLG = bool.Parse(parts[4]);
                    int numberIterationsTotalCLG = int.Parse(parts[5]);
                    int numberIterationsDoneCLG = int.Parse(parts[6]);
                    int bonusCLG = int.Parse(parts[7]);
                    DateTime dateAccomplishedCLG = DateTime.Parse(parts[8]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(titleCLG, descriptionCLG, pointsCLG, isAchievedCLG, numberIterationsTotalCLG, numberIterationsDoneCLG, bonusCLG, dateAccomplishedCLG);
                    _goals.Add(checklistGoal);
                }
            }
            count ++;
        }
    }
    public int GetGoalIndex()
    {
        int range = NumberGoals();
        int index = -1;
        if (range <= 0)
        {
            return index;
        }
        else
        {
            DisplayGoals();
            Console.WriteLine();
            index = GetValidNumber("Select a goal")-1;
            if (index >= range | index < 0)
            {
                Spinner spinner = new Spinner();
                Console.WriteLine("This is not a valid number.");
                spinner.Wait(2);
                index = -1;
                return index;
            }
            else
            {
                return index;
            }
        }
    }
    public Goal GetGoal(int index)
    {
        return _goals[index];
    }
}
