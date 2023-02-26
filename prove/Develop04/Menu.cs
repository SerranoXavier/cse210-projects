using System;

public class Menu
{
    private string _title;
    private List<MenuItem> _menuItems = new List<MenuItem>();


    public Menu(string title = "Menu")
    {
        _title = title;
    }

    private void DisplayMenu() // dislpays the menu, one item per line
    {
        Console.WriteLine(_title);
        Console.WriteLine();
        foreach (MenuItem item in _menuItems)
        {
            item.DisplayMenuItem();
        }
    }
    public void AddMenuItem(int id, string name) // adds an item to the menu
    {
        _menuItems.Add(new MenuItem(id, name));
    }
    public int AskOption() // asks which option the user want to run
    {
        DisplayMenu();
        Console.WriteLine();
        Console.Write("What would you like to do? ");
        return int.Parse(Console.ReadLine());
    }
}