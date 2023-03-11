using System;

public class MenuOption
{
    private int _id;
    private string _name;


    public MenuOption(int id, string name) // adds an option to the menu
    {
        _id = id;
        _name = name;
    }
    
    public void DisplayMenuOption() // displays the option (index and name)
    {
        Console.WriteLine($"{_id} - {_name}");
    }
}