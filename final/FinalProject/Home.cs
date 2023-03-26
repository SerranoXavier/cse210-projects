using System;

public class Home
{
    private int _id;
    private string _name;
    private List<Location> _locations;
    private List<Alert> _alerts;
    private List<GroceryList> _groceryLists;


    public Home()
    {
        _id = 0;
        _name = "Home";
        _locations = new List<Location>();
        _alerts = new List<Alert>();
        _groceryLists = new List<GroceryList>();
    }
    public Home(int id, string name, List<Location> locations, List<GroceryList> groceryLists)
    {
        _id = id;
        _name = name;
        _locations = locations;
        _alerts = new List<Alert>();
        _groceryLists = groceryLists;
    }

    public void DisplayLocations() // if empty to handle
    {
        for (int index = 0; index < _locations.Count(); index++)
        {
            Console.WriteLine($"{index + 1} - {_locations[index].GetName()}");
        }
    }
    public void DisplayOneLocation(int index)
    {
        _locations[index].DisplayFoods();
    }
    public void DisplayAlerts() // if empty to handle
    {
        foreach (Alert alert in _alerts)
        {
            alert.Display();
        }
    }
    public void DisplayGroceryList() // if empty to handle
    {
        for (int index = 0; index < _groceryLists.Count(); index++)
        {
            Console.WriteLine($"{index + 1} - {_groceryLists[index].GetName()}");
        }
    }
    public void AddFood()
    {
        Validator validator = new Validator();
        Console.WriteLine("Add an Item");
        Console.WriteLine();
        DisplayLocations();
        int index = validator.GetValidInt("In which location would you like to add an item? ");
        _locations[index - 1].AddFood();
    }
    // public void RemoveLocation() // if empty to handle
    // {
    //     Validator validator = new Validator();
    //     DisplayLocations();
    //     Console.WriteLine();
    //     Console.ForegroundColor = ConsoleColor.Red;
    //     Console.WriteLine("Warning: Removing a location will remove all the items present in it!");
    //     //back to normal color
    //     int index = validator.GetValidInt("Wich Location do you want to remove?") - 1;
    //     // if 0 exit
    //     _locations.RemoveAt(index);
    // }
    // public void DisplayFoodByLocation() // if empty to handle
    // {
    // }
    // public Alert AddAlert()
    // {
    // }
    // public void Load()
    // {
    // }
    // public void Save()
    // {
    // }
    // public Food AddFood()
    // {
    // }
}
