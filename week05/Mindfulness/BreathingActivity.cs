using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }
    public void Run()
    {
        DisplayStartingMessage();
        int time = 0;
        int x = 3;

        do
        {

            Console.Write($"Breathe in... "); ShowCountDown(x);
            Console.WriteLine();


            time += x;

            Console.Write($"Now breathe out... "); ShowCountDown(x);
            Console.WriteLine();
            Console.WriteLine();
            time += x;
            x = x >= 8 ? x : x + 1;




        } while (time < _duration);
        DisplayEndingMessage();








    }
}