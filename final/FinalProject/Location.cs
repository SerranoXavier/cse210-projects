using System;

public class Location
{
    private int _id;
    private int _idHome;
    private string _name;
    private List<Food> _listFood;


    public Location(int id, int idHome, string name)
    {
        _id = id;
        _idHome = idHome;
        _name = name;
        _listFood = new List<Food>();
    }
    public Location(int id, int idHome, string name, List<Food> listFood)
    {
        _id = id;
        _idHome = idHome;
        _name = name;
        _listFood = listFood;
    }

    public void DisplayFoods()
    {
        Console.WriteLine(_name);
        if (_listFood.Count() == 0)
        {
            Console.WriteLine("This Location is empty.");
        }
        else
        {
            for (int index = 0; index < _listFood.Count(); index++)
            {
                Console.WriteLine($"{index + 1} - {_listFood[index].AsText()}");
            }
        }
    }
    private void AddBulkFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        double quantity = validator.GetValidDouble("Enter quantity (kg):");
        
        BulkFood newFood = new BulkFood(_id, null, name, quantity);
        _listFood.Add(newFood);
    }
    private void AddFruitVegetable()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        double quantity = validator.GetValidDouble("Enter quantity (kg):");

        FruitVegetable newFood = new FruitVegetable(_id, null, name, quantity);
        _listFood.Add(newFood);
    }
    private void AddBeverage()
    {
        Validator validator = new Validator();
        
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        double quantity = validator.GetValidDouble("Enter quantity (L):");

        DateTime expirationDate = validator.GetValidDate("Enter expiration date:");

        Beverage newFood = new Beverage(_id, null, name, quantity, expirationDate);
        _listFood.Add(newFood);
    }
    private void AddPackedFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        int quantity = validator.GetValidInt("Enter quantity:");

        Console.Write("Enter packaging (can, pack...): ");
        string packaging = Console.ReadLine();

        DateTime expirationDate = validator.GetValidDate("Enter expiration date:");

        PackedFood newFood = new PackedFood(_id, null, name, quantity, expirationDate, packaging);
        _listFood.Add(newFood);
    }
    public void AddFood()
    {
        Menu addFoodMenu = new Menu("Add Food");
        addFoodMenu.AddMenuOption(1, "Fruits or Vegetables");
        addFoodMenu.AddMenuOption(2, "Packed Food");
        addFoodMenu.AddMenuOption(3, "Beverage");
        addFoodMenu.AddMenuOption(4, "Bulk Food");
        addFoodMenu.AddMenuOption(5, "Back to Main Menu");
        
        int option;

        do
        {
            option = addFoodMenu.AskOption("Which item do you want to add?");
            switch(option)
            {
                case 1:
                {
                    AddFruitVegetable();
                }
                break;
                case 2:
                {
                    AddPackedFood();
                }
                break;
                case 3:
                {
                    AddBeverage();
                }
                break;
                case 4:
                {
                    AddBulkFood();
                }
                break;
            }
        } while (option != 5);

    }
    public void RemoveFood()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_listFood.Count() == 0)
        {
            Console.WriteLine("This location is empty.");
            spinner.Wait(2);
        }
        else
        {
            Console.Clear();
            DisplayFoods();
            Console.WriteLine();
            int input = validator.GetValidInt("Which item do you want to remove (type 0 to come back to the remove item menu)?", _listFood.Count(), false);
            int index = input -1;
            if (input == 0)
            {
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Food");
                Console.WriteLine();
                _listFood[index].Display();
                Console.WriteLine();
                double quantity = validator.GetValidDouble("Which quantity do you want to remove?", false);
                bool toRemove = _listFood[index].RemoveQuantity(quantity);
                if (toRemove)
                {
                    Console.WriteLine($"{_listFood[index].GetName()} has been removed.");
                    _listFood.RemoveAt(index);
                    spinner.Wait(2);
                }
                else
                {
                    Console.WriteLine($"{_listFood[index].GetName()} has been modified:");
                    _listFood[index].Display();
                    spinner.Wait(4);
                }
            }
        }
    }
    private List<Alert> AlertsExpirationDatePassed()
    {
        List<Alert> alerts = new List<Alert>();

        foreach (Food food in _listFood)
        {
            if (food.IsExpired())
            {
                AlertExpirationDatePassed alert = new AlertExpirationDatePassed(food);
                alerts.Add(alert);
            }
        }

        return alerts;
    }
    private List<Alert> AlertsExpirationDateClose(int days)
    {
        List<Alert> alerts = new List<Alert>();

        foreach (Food food in _listFood)
        {
            if (food.IsExpiredSoon(days))
            {
                AlertExpirationDateClose alert = new AlertExpirationDateClose(food);
                alerts.Add(alert);
            }
        }

        return alerts;
    }
    private List<Alert> AlertsLowQuantity(float threshold)
    {
        List<Alert> alerts = new List<Alert>();

        foreach (Food food in _listFood)
        {
            if (food.IsLowQuantity(threshold))
            {
                AlertQuantity alert = new AlertQuantity(food);
                alerts.Add(alert);
            }
        }

        return alerts;
    }
    public void DisplayAlerts(float quantityThreshold, int days)
    {
        List<Alert> alertsExpired = AlertsExpirationDatePassed();
        List<Alert> alertsExpiredSoon = AlertsExpirationDateClose(days);
        List<Alert> alertsLowQuantity = AlertsLowQuantity(quantityThreshold);

        Console.WriteLine(_name);

        if (alertsExpired.Count() == 0 && alertsExpiredSoon.Count() == 0 && alertsLowQuantity.Count() == 0)
        {
            Console.WriteLine("There is no Alert.");
            Console.WriteLine();
        }
        else
        {
            if (alertsExpired.Count() == 0)
            {
            }
            else
            {
                foreach (Alert alert in alertsExpired)
                {
                    alert.Display();
                }
            }

            if (alertsExpiredSoon.Count() == 0)
            {
            }
            else
            {
                foreach (Alert alert in alertsExpiredSoon)
                {
                    alert.Display();
                }
            }

            if (alertsLowQuantity.Count() == 0)
            {
            }
            else
            {
                foreach (Alert alert in alertsLowQuantity)
                {
                    alert.Display();
                }
            }
            Console.WriteLine();
        }
    }
    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("Location.txt", true))
        {
            outputFile.WriteLine($"{_id}~|~{_idHome}~|~{_name}");
        }
        foreach (Food food in _listFood)
        {
            food.Save();
        }
    }
    public void LoadFood(string fileFood)
    {
        string[] lines = System.IO.File.ReadAllLines(fileFood);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            string type = parts[0];
            int idLocation;
            if (int.TryParse(parts[1], out idLocation))
            {
                idLocation = int.Parse(parts[1]);
            }
            else
            {
                idLocation = -1;
            }
            string name = parts[3];
            double quantity = double.Parse(parts[4]);
            DateTime expirationDate = DateTime.Parse(parts[5]);
            string packaging = parts[6];

            if (idLocation == _id)
            {
                if (type == "PackedFood")
                {
                    PackedFood packedFood = new PackedFood(idLocation, null, name, quantity, expirationDate, packaging);
                    _listFood.Add(packedFood);
                }
                else if (type == "Beverage")
                {
                    Beverage beverage = new Beverage(idLocation, null, name, quantity, expirationDate);
                    _listFood.Add(beverage);
                }
                else if (type == "BulkFood")
                {
                    BulkFood bulkFood = new BulkFood(idLocation, null, name, quantity, expirationDate);
                    _listFood.Add(bulkFood);
                }
                else if (type == "FruitVegetable")
                {
                    FruitVegetable fruitVegetable = new FruitVegetable(idLocation, null, name, quantity, expirationDate);
                    _listFood.Add(fruitVegetable);
                }
            }
        }
    }
    public string GetName()
    {
        return _name;
    }
    public int GetNumberFoods()
    {
        return _listFood.Count();
    }
    public Food GetFood(int index)
    {
        return _listFood[index];
    }
}