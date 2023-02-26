using System;

class Spinner
{
    private List<char> _spinner;


    public Spinner()
    {
        _spinner = new List <char> {'|', '/', '―', '\\'};
    }
    public Spinner(List<char> spinner)
    {
        _spinner = spinner;
    }

    private void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    private void DisplaySpinner()
    {
        foreach (char character in _spinner)
        {
            Console.Write(character);
            Task.Delay(250).Wait();
            ClearLine();
        }
    }
    public void Wait(int timeDuration)
    {
        var startTime = DateTime.UtcNow;
        while(DateTime.UtcNow - startTime < TimeSpan.FromSeconds(timeDuration))
            {
                DisplaySpinner();
            }
    }
}