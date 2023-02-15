using System;

public class MenuItem
{
    private int _id;
    private string _name;

        public MenuItem(int id, string name) // adds an item to the menu
    {
        _id = id;
        _name = name;
    }
    public void DisplayMenuItem() // displays the item (index and name)
    {
        Console.WriteLine($"{_id} - {_name}");
    }
}