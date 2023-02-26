// exceeding requirements: I coded a progress bar for displaying the duration of the activity

using System;

public class ProgressBar
{
    private string _type;
    private int _length;
    private int _duration;
    private char _fillChar;
    private char _emptyChar;


    public ProgressBar()
    {
        _type = "time";
        _length = 50;
        _duration = 10;
        _fillChar = '-';
        _emptyChar = ' ';
    }
    public ProgressBar(string type = "time", int length = 50, int duration = 10, char fillChar = '-', char emptyChar = ' ')
    {
        _type = type;
        _length = length;
        _duration = duration;
        _fillChar = fillChar;
        _emptyChar = emptyChar;
    }

    private void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    public void Progression()
        {
            var startTime = DateTime.UtcNow;
            while(DateTime.UtcNow - startTime < TimeSpan.FromSeconds(_duration))
                {
                    for (int i=0; i < (_duration + 1); i++)
                    {
                        string progressBar = "";
                        int progressionTime = (int)Math.Round((float)(i * _length / _duration));
                        int progressionPercent = (int)Math.Round((float)(i * 100 / _duration));
                        for (int j=0; j < progressionTime; j++)
                        {
                            progressBar += _fillChar;
                        }
                        for (int k=0; k < (_length - progressionTime); k++)
                        {
                            progressBar += _emptyChar;
                        }
                        Console.Write("[" + progressBar + "]");
                        if (_type.ToLower() == "time")
                        {
                            Console.Write(" " + i + "s");  // time in second
                        } else if (_type.ToLower() == "percent")
                        {
                        Console.Write(" " + progressionPercent + "%");  // progression in %
                        }
                        Task.Delay(1000).Wait();
                        ClearLine();
                    }
                }
        }
}