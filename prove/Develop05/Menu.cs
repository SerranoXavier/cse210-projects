using System;

public class Menu
{
    private string _title;
    private List<MenuOption> _menuOptions = new List<MenuOption>();


    public Menu(string title = "Menu")
    {
        _title = title;
    }

    private void DisplayMenu() // dislpays the menu, one option per line
    {
        Console.WriteLine(_title);
        Console.WriteLine();
        foreach (MenuOption item in _menuOptions)
        {
            item.DisplayMenuOption();
        }
    }
    public void AddMenuOption(int id, string name) // adds an option to the menu
    {
        _menuOptions.Add(new MenuOption(id, name));
    }
    public int AskOption(string prompt = "What would you like to do?") // asks which option the user wants to run
    {
        bool isInt = false;
        int option = 0;
        int range = _menuOptions.Count();
        Spinner spinner = new Spinner();
        while (!isInt)
        {
            Console.Clear();
            DisplayMenu();

            Console.WriteLine();
            Console.Write($"{prompt} ");

            string input = Console.ReadLine();
            if(int.TryParse(input, out option)) // test if input can be parse as an integer
            {
                option = int.Parse(input);
                if (option > 0 & option <= range) // test if option within the range of available options
                {
                    isInt = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid option.");
                    spinner.Wait(2);
                }
            }
            else
            {
                Console.WriteLine("This is not a valid option.");
                spinner.Wait(2);
            }
        }
        return option;
    }
}