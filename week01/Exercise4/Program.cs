using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;
        int sum = 0;
        int largest = int.MinValue;
        int smallest = int.MaxValue;
        Console.WriteLine("Enter a list of umbers, type 0 when finisher.");

        while (true)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber == 0)
            {
                break;
            }
            numbers.Add(userNumber);

        }
        foreach (int number in numbers)
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            }
            else if (number > 0 && number < smallest)
            {
                smallest = number;
            }
        }

        double avg = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        Console.WriteLine($"The total is {sum}");
        Console.WriteLine($"The average is {avg}");
        Console.WriteLine($"The largest is {largest}");
        Console.WriteLine($"The smallest positive is {smallest}");
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }





    }
}