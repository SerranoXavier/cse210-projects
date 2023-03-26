using System;

public abstract class Alert
{
    private protected int _id;
    private protected Food _food;


    public Alert(int id, Food food)
    {
        _id = id;
        _food = food;
    }

    public abstract void Display();
}
