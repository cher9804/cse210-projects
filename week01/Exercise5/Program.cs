using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to this point");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        static int SquareNumber(int number)
        {
            number = number * number;
            return number;
        }
        static void DisplayResult(int number, string name)
        {
            Console.WriteLine($"{name}, the square of your number is {number}");

        }

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareNumber = SquareNumber(userNumber);
        DisplayResult(squareNumber, userName);

    }
}