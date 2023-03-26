using System;

public abstract class Food
{
    private protected int _id;
    private protected string _name;
    private protected double _quantity;
    private protected DateTime _expirationDate;


    public Food(int id, string name, double quantity, DateTime expirationDate)
    {
        _id = id;
        _name = name;
        _quantity = quantity;
        _expirationDate = expirationDate;
    }

    public abstract void Display();
    public abstract string AsText();
    public virtual string Export()
    {
        return _name;
    }
}