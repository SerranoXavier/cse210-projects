using System;

public class Activity
{
    private string _startingMessage;
    private string _endingMessage;
    private List<string> _prompts;


    public Activity(string startingMessage, string endingMessage, List<string> prompts)
    {
        _startingMessage = startingMessage;
        _endingMessage = endingMessage;
        _prompts = prompts;
    }
    

    public void DisplayStartingMessage(int waitingTime)
    {
        Spinner spinner = new Spinner();
        Console.WriteLine(_startingMessage);
        spinner.Wait(waitingTime);
    }
    public void DisplayEndingMessage(int time, string activity)
    {
        Spinner spinner = new Spinner();
        Console.WriteLine(_endingMessage);
        spinner.Wait(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed {time} seconds of the {activity}.");
        spinner.Wait(5);
    }
    public void DisplayRandomPrompt(string message, bool pressEnter)
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        Console.WriteLine(message);
        Console.WriteLine();
        Console.WriteLine("    - " + _prompts[index]);
        Console.WriteLine();
        if (pressEnter)
        {
            Console.Write("When you have something in mind, press enter... ");
            Console.ReadLine();
        }
        else
        {
            Spinner spinner = new Spinner();
            spinner.Wait(5);
        }
    }
    public void GetReady(string message, int waitingTime)
    {
        Spinner spinner = new Spinner();
        Console.WriteLine(message);
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        spinner.Wait(waitingTime);
    }
    public int DetermineNumberTimes(int durationSteps, int waitTime)
    {
        Spinner spinner = new Spinner();
        Console.Write("How long approximately, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        int numberTimes = (int)Math.Round((duration / (double)durationSteps));
        switch (numberTimes)
        {
            case 0 or 1:
                Console.WriteLine();
                Console.WriteLine("You will perform the activity 1 time.");
                spinner.Wait(waitTime);
                return 1;
            default:
                Console.WriteLine();
                Console.WriteLine($"You will perform the activity {numberTimes} times.");
                spinner.Wait(waitTime);

                return numberTimes;
        }
    }
}