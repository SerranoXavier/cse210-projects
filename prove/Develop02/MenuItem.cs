using System;

public class MenuItem
{
    public int _id;
    public string _name;

    public void DisplayMenuItem() // displays the item (index and name)
    {
        Console.WriteLine($"{_id} - {_name}");
    }
}