using System;

public abstract class Alert
{
    private protected Food _food;


    public Alert(Food food)
    {
        _food = food;
    }

    public abstract void Display();
}
