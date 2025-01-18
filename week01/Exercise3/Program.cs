using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber;
        int guess;
        Random randomGenerator = new Random();
        magicNumber = randomGenerator.Next(1,101);

        do
        {
            Console.Write("What is your guess? ");
            string userGuess = Console.ReadLine();
            guess = int.Parse(userGuess);
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");

            }
            else
            {
                Console.WriteLine("You guess it!");
            }
        }
        while (guess != magicNumber);
    }
}