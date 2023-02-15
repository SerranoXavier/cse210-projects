using System;

public class Menu
{
    private List<MenuItem> _menuItems = new List<MenuItem>();

    public void DisplayMenu(string menu) // dislpays the menu, one item per line with a title (provided as argument)
    {
        Console.WriteLine(menu);
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
    public int AskOption(string menu) // asks which option the user want to run (the title of the menu is provided as an argument)
    {
        DisplayMenu(menu);
        Console.WriteLine();
        Console.Write("What would you like to do? ");
        return int.Parse(Console.ReadLine());
    }
}