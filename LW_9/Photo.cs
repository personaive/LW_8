using System;

public class Photo
{
    private string _name;
    private string _author;
    private int _year;
    private int _width;
    private int _height;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }

    public Photo()
    {
    }

    public Photo(string name, string author, int year, int width, int height)
    {
        _name = name;
        _author = author;
        _year = year;
        _width = width;
        _height = height;
    }

    public override string ToString()
    {
        return _name + " | " + _author + " | " + _year + " | " + _width + "x" + _height;
    }
}