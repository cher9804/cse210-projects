using System;
using System.Transactions;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
};
    private List<string> _questions = new List<string>
    {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
};
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }
    public void Run()
    {
        DisplayStartingMessage();
        int time = 0;
        do
        {
            Console.WriteLine(
            $"""
            Consider the following prompt:

            --- {GetRandomPrompt()} ---

            When you have something in mind, press enter to continue.
            """);
            Console.ReadLine();
            Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may being in: ");
            ShowCountDown(5);
            time += 5;
            Console.Clear();
            do
            {
                Console.Write($"> {GetRandomQuestion()} ");
                ShowSpinner();
                time +=5;

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
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];

    }
    public void DisplayPrompt()
    {
        

    }
    public void DisplayQuestions()
    {

    }

}