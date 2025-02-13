using System;
using System.Security.Cryptography.X509Certificates;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();
        int time = 0;
        do
        {
            Console.Write(
            $"""
            List as many responses you can to the following prompt:

            --- {GetRandomPrompt()} ---

            You may begin in: 
            """);
            ShowCountDown(5);

            Console.WriteLine();
            do
            {
                Console.Write($"> ");
                string input = Console.ReadLine();
                // Console.WriteLine
                time += 5;

            } while (time < _duration);
            Console.WriteLine();
        } while (time < _duration);
        DisplayEndingMessage();

    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> X = new List<string>();
        return X;
    }
}