using System;

public class Home
{
    private int _id;
    private string _name;
    private List<Location> _locations;
    private List<Alert> _alerts;
    private List<GroceryList> _groceryLists;


    public Home(int id)
    {
        _id = id;
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

    private void DisplayLocations()
    {
        for (int indexList = 0; indexList < _locations.Count(); indexList++)
        {
            Console.WriteLine($"{indexList + 1} - {_locations[indexList].GetName()}");
        }
    }
    public void AskLocation()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_locations.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Locations");
            Console.WriteLine();
            Console.WriteLine("There is no Location.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;
            while (input != 0)
            {
                Console.Clear();
                Console.WriteLine("Locations");
                Console.WriteLine();
                DisplayLocations();
                Console.WriteLine();
                input = validator.GetValidInt("Choose a Location to visualize (type 0 to come back to the main menu):", _locations.Count(), false);
                int indexLocation = input - 1;
                Console.Clear();
                if (input == 0)
                {
                }
                else
                {
                    DisplayOneLocation(indexLocation);
                    Console.WriteLine();
                    Console.Write("Press enter to exit...");
                    Console.ReadLine();
                }
            }
        }
    }
    private void DisplayOneLocation(int index)
    {
        _locations[index].DisplayFoods();
    }
    private void DisplayGroceryLists()
    {
        for (int indexList = 0; indexList < _groceryLists.Count(); indexList++)
        {
            Console.WriteLine($"{indexList + 1} - {_groceryLists[indexList].GetName()}");
        }
    }
    public void AskGroceryList()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_groceryLists.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Grocery Lists");
            Console.WriteLine();
            Console.WriteLine("There is no Grocery List.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;
            while (input != 0)
            {
                Console.Clear();
                Console.WriteLine("Grocery Lists");
                Console.WriteLine();
                DisplayGroceryLists();
                Console.WriteLine();
                input = validator.GetValidInt("Choose a Grocery List to visualize (type 0 to come back to the main menu):", _groceryLists.Count(), false);
                int indexGroceryList = input - 1;
                Console.Clear();
                if (input == 0)
                {
                }
                else
                {
                    DisplayOneGroceryList(indexGroceryList);
                    Console.WriteLine();
                    Console.Write("Press enter to exit...");
                    Console.ReadLine();
                }
            }
        }
    }
    private void DisplayOneGroceryList(int index)
    {
        _groceryLists[index].Display();
    }
    private void DisplayGroceryListsNames()
    {
        for (int index = 0; index < _groceryLists.Count(); index++)
        {
            Console.WriteLine($"{index + 1} - {_groceryLists[index].GetName()}");
        }
    }
    public void AddGroceryList()
    {
        Spinner spinner = new Spinner();

        Console.Clear();
        Console.WriteLine("Add a Grocery List");
        Console.WriteLine();
        Console.Write("What is the name of the grocery list? ");
        string name = Console.ReadLine();
        int idGroceryList = _groceryLists.Count() + 1;

        GroceryList groceryList = new GroceryList(idGroceryList, _id, name);
        _groceryLists.Add(groceryList);
        
        Console.WriteLine($"{groceryList.GetName()} has been added.");
        spinner.Wait(2);
    }
    public void RemoveGroceryList()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_groceryLists.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Remove Grocery List");
            Console.WriteLine();
            Console.WriteLine("There is no Grocery List.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;
            while (input != 0)
            {
                Console.Clear();
                Console.WriteLine("Remove Grocery List");
                Console.WriteLine();

                DisplayGroceryLists();
                Console.WriteLine();

                input = validator.GetValidInt("Wich Grocery List do you want to remove (type 0 to come back to Grocery List Manager)?", _groceryLists.Count(), false);
                int index = input - 1;
                if (input == 0)
                {
                }
                else
                {
                    _groceryLists.RemoveAt(index);
                    Console.WriteLine("The Grocery List has been removed.");
                    spinner.Wait(2);
                }
            }
        }
    }
    public void ExportGroceryList()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_groceryLists.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Export Grocery List");
            Console.WriteLine();
            Console.WriteLine("There is no Grocery List.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;
            while (input != 0)
            {
                Console.Clear();
                Console.WriteLine("Export Grocery List");
                Console.WriteLine();
                DisplayGroceryListsNames();
                Console.WriteLine();
                input = validator.GetValidInt("Which Grocery List would you like to export (Type 0 to come back to the Grocery List Manager)?", _groceryLists.Count(), false);
                int index = input - 1;
                if (input == 0)
                {
                }
                else
                {
                    _groceryLists[index].Export();
                }
            }
        }
    }
    public void EditGroceryList()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        Menu editGroceryListMenu = new Menu("Edit Grocery List");
        editGroceryListMenu.AddMenuOption(1, "Add a new item");
        editGroceryListMenu.AddMenuOption(2, "Add an existing item");
        editGroceryListMenu.AddMenuOption(3, "Remove an item");
        editGroceryListMenu.AddMenuOption(4, "Back to Grocery List Manager");

        int option;
        string prompt = "What would you like to do?";

        do
        {
        option = editGroceryListMenu.AskOption(prompt);
        switch(option)
        {
            case 1: // Add a new item
            {
                Console.Clear();
                Console.WriteLine("Add a new item");
                Console.WriteLine();
                DisplayGroceryListsNames();
                Console.WriteLine();

                int input = validator.GetValidInt("In which Grocery List would you like to add a new item (type 0 to come back to Edit Grocery List)?", _groceryLists.Count(), false);
                int index = input - 1;
                if (input == 0)
                {
                }
                else
                {
                    _groceryLists[index].AddFood();
                }
            }
            break;
            case 2: // Add an existing item
            {
                Console.Clear();
                Console.WriteLine("Add an existing item");
                Console.WriteLine();
                DisplayGroceryListsNames();
                Console.WriteLine();

                int inputGroceryList = validator.GetValidInt("In which Grocery List would you like to add an existing item (type 0 to come back to Edit Grocery List)?", _groceryLists.Count(), false);
                int indexGroceryList = inputGroceryList - 1;
                if (inputGroceryList == 0)
                {
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Add an existing item");
                    Console.WriteLine();
                    DisplayLocations();
                    Console.WriteLine();

                    int inputLocation = validator.GetValidInt("From which Location would you like to pick an item (type 0 to come back to Edit Grocery List)?", _locations.Count(), false);
                    int indexLocation = inputLocation - 1;
                    if (inputLocation == 0)
                    {
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Add an existing item");
                        Console.WriteLine();
                        _locations[indexLocation].DisplayFoods();
                        Console.WriteLine();

                        int inputFood = validator.GetValidInt("Which item would you like to pick (type 0 to come back to the Location list)? ", _locations[indexLocation].GetNumberFoods(), false);
                        int indexFood = inputFood - 1;
                        if (inputFood == 0)
                        {
                        }
                        else
                        {
                            _groceryLists[indexGroceryList].AddExistingFood(_locations[indexLocation].GetFood(indexFood));
                        }
                    }
                }
            }
            break;
            case 3: // Remove an item
            {
                Console.Clear();
                Console.WriteLine("Remove an item");
                Console.WriteLine();
                DisplayGroceryLists();
                Console.WriteLine();

                int input = validator.GetValidInt("In which grocery list would you like to remove an item (type 0 to come back to Edit Grocery List)?", _groceryLists.Count(), false);
                int index = input - 1;
                if (input == 0)
                {
                }
                else
                {
                    _groceryLists[index].RemoveFood();
                }
            }
            break;
        }
        } while (option != 4);
    }
    public void DisplayFoodByLocation()
    {
        Console.Clear();
        Console.WriteLine("Food by Location");
        Console.WriteLine();
        Console.WriteLine();

        if (_locations.Count() == 0)
        {
            Console.WriteLine("There is no location.");
        }
        else
        {
            foreach (Location location in _locations)
            {
                location.DisplayFoods();
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        Console.Write("Press enter to exit...");
        Console.ReadLine();
    }
    public void AddFood()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_locations.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Add Food");
            Console.WriteLine();
            Console.WriteLine("There is no Location.");
            spinner.Wait(2);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Add Food");
            Console.WriteLine();

            DisplayLocations();
            Console.WriteLine();

            int input = validator.GetValidInt("In which location would you like to add an item (type 0 to come back to the main menu)?", _locations.Count(), false);
            int index = input - 1;
            if (input == 0)
            {
            }
            else
            {
                _locations[index].AddFood();
            }
        }
    }
    public void RemoveFood()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_locations.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Remove Food");
            Console.WriteLine();
            Console.WriteLine("There is no Location.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Remove Food");
                Console.WriteLine();
                DisplayLocations();
                input = validator.GetValidInt("In which location would you like to remove an item (type 0 to come back to the location manager menu)?", _locations.Count(), false);
                int index = input -1;
                if (input == 0)
                {
                }
                else
                {
                    _locations[index].RemoveFood();
                }
            } while (input != 0);
        }
    }
    public void AddLocation()
    {
        Spinner spinner = new Spinner();

        Console.Clear();
        Console.WriteLine("Add Location");
        Console.WriteLine();

        Console.Write("What is the name of the location? ");
        string name = Console.ReadLine();
        int idLocation = _locations.Count() + 1;
        Location newLocation = new Location(idLocation, _id, name);
        _locations.Add(newLocation);
        Console.WriteLine($"{name} has been added.");
        spinner.Wait(2);
    }
    public void RemoveLocation()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_locations.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine("Remove Location");
            Console.WriteLine();
            Console.WriteLine("There is no location.");
            spinner.Wait(2);
        }
        else
        {
            int input;
            do
            {
                Console.Clear();
                DisplayLocations();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: Removing a Location will remove all the items present in it!");
                Console.ResetColor();
                input = validator.GetValidInt("Wich Location do you want to remove (type 0 to come back to the main menu)?", _locations.Count(), false);
                if (input == 0)
                {
                }
                else if (input > 0) // && input <= _locations.Count()
                {
                    _locations.RemoveAt(input - 1);
                    Console.WriteLine("The Location has been removed.");
                    spinner.Wait(2);
                }
            } while (input != 0);
        }
    }
    public void DisplayAlerts(float quantityThreshold, int days)
    {
        Console.Clear();
        Console.WriteLine("Alerts");
        Console.WriteLine();
        if (_locations.Count() == 0)
        {
            Console.WriteLine("There is no Alert.");
        }
        else
        {
            foreach (Location location in _locations)
            {
                location.DisplayAlerts(quantityThreshold, days);
            }
        }
        Console.Write("Press enter to exit...");
        Console.ReadLine();
    }
    public void Load(string fileHome, string fileLocation, string fileGroceryList, string fileFood)
    {
        string[] lines = System.IO.File.ReadAllLines(fileHome);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            _id = int.Parse(parts[0]);
            _name = parts[1];
        }
        LoadLocation(fileLocation);
        foreach (Location location in _locations)
        {
            location.LoadFood(fileFood);
        }
        LoadGroceryList(fileGroceryList);
        foreach (GroceryList groceryList in _groceryLists)
        {
            groceryList.LoadFood(fileFood);
        }
    }
    private void LoadLocation(string fileLocation)
    {
        string[] lines = System.IO.File.ReadAllLines(fileLocation);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            int id = int.Parse(parts[0]);
            int idHome = int.Parse(parts[1]);
            string name = parts[2];

            if (idHome == _id)
            {
                Location location = new Location(id, idHome, name);
                _locations.Add(location);
            }
        }
    }
    private void LoadGroceryList(string fileGroceryList)
    {
        string[] lines = System.IO.File.ReadAllLines(fileGroceryList);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            int id = int.Parse(parts[0]);
            int idHome = int.Parse(parts[1]);
            string name = parts[2];

            if (idHome == _id)
            {
                GroceryList groceryList = new GroceryList(id, idHome, name);
                _groceryLists.Add(groceryList);
            }
        }
    }
    private void ClearFiles()
    {
        using (StreamWriter outputFile = new StreamWriter("Home.txt"))
        {
        }
        using (StreamWriter outputFile = new StreamWriter("Location.txt"))
        {
        }
        using (StreamWriter outputFile = new StreamWriter("GroceryList.txt"))
        {
        }
        using (StreamWriter outputFile = new StreamWriter("Food.txt"))
        {
        }
    }
    public void Save()
    {
        ClearFiles();
        using (StreamWriter outputFile = new StreamWriter("Home.txt", true))
        {
            outputFile.WriteLine($"{_id}~|~{_name}");
        }
        foreach (Location location in _locations)
        {
            location.Save();
        }
        foreach (GroceryList groceryList in _groceryLists)
        {
            groceryList.Save();
        }
    }
}
