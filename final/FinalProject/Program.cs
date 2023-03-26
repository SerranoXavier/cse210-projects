using System;

class Program
{
    static void Main(string[] args)
    {
        // creation of menus (main menu and Add Food menu)
        Menu mainMenu = new Menu("Food Inventory");
        mainMenu.AddMenuOption(1, "List Locations");
        mainMenu.AddMenuOption(2, "List Food by Location");
        mainMenu.AddMenuOption(3, "List Alerts");
        mainMenu.AddMenuOption(4, "Add Food");
        mainMenu.AddMenuOption(5, "Remove Food");
        mainMenu.AddMenuOption(6, "Add Location");
        mainMenu.AddMenuOption(7, "Remove Location");
        mainMenu.AddMenuOption(8, "Quit");

        // creation of global variables
        int optionMain = 0;
        Spinner spinner = new Spinner();
        Validator validator = new Validator();


        List<Food> listFoodPantry = new List<Food>()
        {
            new BulkFood(0, "Banana", 1.5),
            new PackedFood(0, "Almonds", 2, DateTime.Parse("31/07/2024"), "jar")
        };
        List<Food> listFoodFridge = new List<Food>()
        {
            new Beverage(0, "Milk", 4, DateTime.Parse("05/04/2023"))
        };

        List<Location> listLocationHome = new List<Location>()
        {
            new Location(0, "Fridge", listFoodFridge),
            new Location(0, "Pantry", listFoodPantry)
        };
        List<GroceryList> listGroceryList = new List<GroceryList>()
        {
            new GroceryList(0, "Fridge", listFoodFridge),
            new GroceryList(0, "Pantry", listFoodPantry)
        };

        Home home = new Home(0, "Home", listLocationHome, listGroceryList);

        // start
        do
        {
            string prompt = "What would you like to do?";
            optionMain = mainMenu.AskOption(prompt);

            switch(optionMain)
            {
                case 1: // List Locations
                {
                    int option = -1;
                    while (option != 0)
                    {
                        Console.Clear();
                        home.DisplayLocations();
                        Console.WriteLine();
                        option = validator.GetValidInt("Choose a Location to visualize (type 0 to go back to the main menu): ", false);

                        Console.Clear();
                        if (option > 0)
                        {
                            home.DisplayOneLocation(option - 1);
                            Console.WriteLine();
                            Console.WriteLine("Hit a key to exit...");
                            Console.ReadLine();
                        }
                    }
                }
                break;
                case 2: // List Food by Location
                {
                    Console.Clear();
                    Console.WriteLine("Work in progress...");
                    Console.WriteLine("Hit a key to exit...");
                    Console.ReadLine();
                }
                break;
                case 3: // List Alerts
                {
                    Console.Clear();
                    Console.WriteLine("Work in progress...");
                    Console.WriteLine("Hit a key to exit...");
                    Console.ReadLine();
                }
                break;
                case 4: // Add Food
                {
                    Console.Clear();
                    home.AddFood();
                }
                break;
                case 5: // Remove Food
                {
                    Console.Clear();
                    Console.WriteLine("Work in progress...");
                    Console.WriteLine("Hit a key to exit...");
                    Console.ReadLine();
                }
                break;
                case 6: // Add Location
                {
                    Console.Clear();
                    Console.WriteLine("Work in progress...");
                    Console.WriteLine("Hit a key to exit...");
                    Console.ReadLine();
                }
                break;
                case 7: // Remove Location
                {
                    Console.Clear();
                    Console.WriteLine("Work in progress...");
                    Console.WriteLine("Hit a key to exit...");
                    Console.ReadLine();
                }
                break;
            }
        } while (optionMain != 8);
    
    Console.Clear();
    Console.WriteLine("Goodbye!");
    }
}