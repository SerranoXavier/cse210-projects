using System;
using System.Globalization;


class Program
{
    static void Main(string[] args)
    {
        // creation of menus (main menu, Location Manager menu and Grocery List Manager menu)
        Menu mainMenu = new Menu("Food Inventory");
        mainMenu.AddMenuOption(1, "List Locations");
        mainMenu.AddMenuOption(2, "List Food by Location");
        mainMenu.AddMenuOption(3, "List Alerts");
        mainMenu.AddMenuOption(4, "List Grocery Lists");
        mainMenu.AddMenuOption(5, "Add Food");
        mainMenu.AddMenuOption(6, "Remove Food");
        mainMenu.AddMenuOption(7, "Location Manager");
        mainMenu.AddMenuOption(8, "Grocery List Manager");
        mainMenu.AddMenuOption(9, "Quit");

        Menu locationMenu = new Menu("Location Manager");
        locationMenu.AddMenuOption(1, "List Locations");
        locationMenu.AddMenuOption(2, "Add Location");
        locationMenu.AddMenuOption(3, "Remove Location");
        locationMenu.AddMenuOption(4, "Main Menu");

        Menu groceryListMenu = new Menu("Grocery List Manager");
        groceryListMenu.AddMenuOption(1, "List Grocery List");
        groceryListMenu.AddMenuOption(2, "Export Grocery List");
        groceryListMenu.AddMenuOption(3, "Add Grocery List");
        groceryListMenu.AddMenuOption(4, "Edit Grocery Lists");
        groceryListMenu.AddMenuOption(5, "Remove Grocery List");
        groceryListMenu.AddMenuOption(6, "Main Menu");

        // creation of global variables
        int optionMain = 0;
        int optionLocation = 0;
        int optionGroceryList = 0;
        float quantityThreshold = 2; // quantity below which an alert is risen
        int days = 7; // number of days before when an alert is risen
        string prompt = "What would you like to do?"; // prompt for asking the menus option
        string fileHome = "Home.txt"; // filename where to store Home data
        string fileLocation = "Location.txt"; // filename where to store Location data
        string fileGroceryList = "GroceryList.txt"; // filename where to store GroceryList data
        string fileFood = "Food.txt"; // filename where to store Food data

        Spinner spinner = new Spinner();
        Validator validator = new Validator();


        // create new Home
        Home home = new Home(1);
        // Load Home from saved file
        home.Load(fileHome, fileLocation, fileGroceryList, fileFood);

        // start
        do
        {
            optionMain = mainMenu.AskOption(prompt);

            switch(optionMain)
            {
                case 1: // List Locations
                {
                    home.AskLocation();
                }
                break;
                case 2: // List Food by Location
                {
                    home.DisplayFoodByLocation();
                }
                break;
                case 3: // List Alerts
                {
                    home.DisplayAlerts(quantityThreshold, days);
                }
                break;
                case 4: // List Grocery Lists
                {
                    home.AskGroceryList();
                }
                break;
                case 5: // Add Food
                {
                    home.AddFood();
                }
                break;
                case 6: // Remove Food
                {
                    home.RemoveFood();
                }
                break;
                case 7: // Location Manager
                {
                    do
                    {
                        optionLocation = locationMenu.AskOption(prompt);
                        switch(optionLocation)
                        {
                            case 1: // Add Location
                            {
                                home.AskLocation();
                            }
                            break;
                            case 2: // Add Location
                            {
                                home.AddLocation();
                            }
                            break;
                            case 3: // Remove Location
                            {
                                home.RemoveLocation();
                            }
                            break;
                        }
                    } while (optionLocation != 4);
                }
                break;
                case 8: // Grocery List Manager
                {
                    do
                    {
                        optionGroceryList = groceryListMenu.AskOption(prompt);
                        switch(optionGroceryList)
                        {
                            case 1: // List Grocery Lists
                            {
                                home.AskGroceryList();
                            }
                            break;
                            case 2: // Export Grocery List
                            {
                                home.ExportGroceryList();
                            }
                            break;
                            case 3: // Add Grocery List
                            {
                                home.AddGroceryList();
                            }
                            break;
                            case 4: // Edit Grocery Lists
                            {
                                home.EditGroceryList();
                            }
                            break;
                            case 5: // Remove Grocery List
                            {
                                home.RemoveGroceryList();
                            }
                            break;
                        }
                    } while (optionGroceryList != 6);
                }
                break;
            }
        } while (optionMain != 9);
    

    home.Save();
    Console.Clear();
    Console.WriteLine("Food Inventory has been saved.");
    spinner.Wait(2);
    Console.Clear();
    Console.WriteLine("Goodbye!");
    Console.WriteLine();
    }
}