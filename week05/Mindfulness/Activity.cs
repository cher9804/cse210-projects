using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public string GetDescription()
    {
        return _description;
    }
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void SetDuration()
    {
        Console.Write("How long, in seconds, would you like to for your session? ");
        int duration = int.Parse(Console.ReadLine());
        _duration = duration;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine($"{_description}\n");
        SetDuration();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner();

    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!");
        ShowSpinner();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner();

    }
    public void ShowSpinner(int seconds = 1)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        List<string> spinnerList = new List<string>() { "|", "/", "\u2014", "\\" };
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinnerList[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;
            if (i >= spinnerList.Count)
            {
                i = 0;
            }
        }
        Console.WriteLine();



    }
    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);
            // Console.Write("\r" + new string(' ', i.ToString().Length) + "\r"); // Clears and resets cursor
            int length = i.ToString().Length;
            Console.Write(new string('\b', length)); // Move the cursor back by the length of the number
            Console.Write(new string(' ', length)); // Overwrite the number with spaces
            Console.Write(new string('\b', length)); // Move the cursor back again to overwrite it in the next iteration
        }

    }

}