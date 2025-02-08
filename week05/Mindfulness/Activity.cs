using System;


class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;

    }
    public string GetDescription()
    {
        return _description;
    }
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine($"{_description}");


    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");

    }
    public void ShowSpinner(int seconds)
    {

    }
    public void ShowCountDown(int second)
    {

    }

}