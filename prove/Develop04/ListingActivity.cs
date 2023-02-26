using System;

public class ListingActivity : Activity
{
    private List<string> _inputsList;


    public ListingActivity(
        string startingMessage,
        string endingMessage,
        List<string> prompts,
        List<string> inputsList)
        : base(startingMessage, endingMessage, prompts)
    {
        _inputsList = inputsList;
    }

    public void DisplayInputsAmount()
    {
        Console.WriteLine(_inputsList.Count);
    }
    public void WaitResponse()
    {
        Console.Write("    > ");
        _inputsList.Add(Console.ReadLine());
    }
    public void DisplayNumberAnswers()
    {
        Spinner spinner = new Spinner();
        Console.WriteLine($"You listed {_inputsList.Count()} items.");
        spinner.Wait(5);
    }
}