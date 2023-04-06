using System;

public abstract class Food
{
    protected int? _idLocation;
    protected int? _idGroceryList;
    protected string _name;
    protected double _quantity;
    protected DateTime _expirationDate;


    public Food(int? idLocation, int? idGroceryList, string name)
    {
        _idLocation = idLocation;
        _idGroceryList = idGroceryList;
        _name = name;
    }
    public Food(int? idLocation, int? idGroceryList, string name, double quantity, DateTime expirationDate)
    {
        _idLocation = idLocation;
        _idGroceryList = idGroceryList;
        _name = name;
        _quantity = quantity;
        _expirationDate = expirationDate;
    }

    private protected string DisplayDate(DateTime date)
    {
        return date.ToShortDateString();
    }
    public abstract void Display();
    public abstract string AsText();
    public abstract void Save();
    public virtual string Export()
    {
        return _name;
    }
    public bool IsLowQuantity(float threshold)
    {
        if (_quantity <= threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsExpiredSoon(int days)
    {
        DateTime today = DateTime.Today;
        if (_expirationDate <= today.AddDays(+days) && _expirationDate >= today)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsExpired()
    {
        DateTime today = DateTime.Today;
        if (_expirationDate < today)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool RemoveQuantity(double quantityToRemove)
    {
        if (quantityToRemove == 0)
        {
            return false;
        }
        else if (quantityToRemove >= _quantity)
        {
            _quantity = 0;
            return true;
        }
        else
        {
            _quantity -= quantityToRemove;
            return false;
        }
    }
    public string GetName()
    {
        return _name;
    }
    public double GetQuantity()
    {
        return _quantity;
    }
    public DateTime GetExpirationDate()
    {
        return _expirationDate;
    }
    public virtual string GetPackaging()
    {
        return null;
    }
}