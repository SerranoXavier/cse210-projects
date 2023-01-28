using System;

public class Entry
{
    public string _prompt;
    public string _response;
    public DateTime _date; // date in date format (exceed requirements)

    public void DisplayEntry() // displays nicely the entries on the console
    {
        Console.WriteLine(_date.ToShortDateString());
        Console.WriteLine(_prompt);
        Console.Write("> ");
        Console.WriteLine(_response);
    }
}