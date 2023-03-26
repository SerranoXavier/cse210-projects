using System;

public class GroceryList
{
    private int _id;
    private string _name;
    private List<Food> _listFood;


    public GroceryList(string name)
    {
        _id = 0;
        _name = name;
        _listFood = new List<Food>();
    }
    public GroceryList(int id, string name, List<Food> listFood)
    {
        _id = id;
        _name = name;
        _listFood = listFood;
    }
    public void Display() // if empty to handle
    {
        Console.WriteLine(_name);
        foreach (Food food in _listFood)
        {
            food.Display();
        }
    }
    public void Export()
    {
        // Ask for the file name
        Console.Write("What is the filename for the grocery list file? ");
        string fileName = Console.ReadLine();

        // Write the points and the goals into a file
        if (!fileName.Contains(".txt"))
        {
            fileName += ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_name);
            outputFile.WriteLine();
            foreach (Food food in _listFood)
            {
                outputFile.WriteLine($"[ ]  {food.Export()}");
            }
        }
    }
    public string GetName()
    {
        return _name;
    }
}

