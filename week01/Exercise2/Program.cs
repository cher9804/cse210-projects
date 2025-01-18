using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Grade Percentage: ");
        string grade = Console.ReadLine();
        int gradeInt = int.Parse(grade);
        string gradeLetter = "";

        if (gradeInt >= 90)
        {
            gradeLetter = "A";
            Console.WriteLine($"Your grade is {gradeLetter}");

        }
        else if (gradeInt >= 80)
        {
            gradeLetter = "B";
            Console.WriteLine($"Your grade is {gradeLetter}");


        }
        else if (gradeInt >= 70)
        {
            gradeLetter = "C";
            Console.WriteLine($"Your grade is {gradeLetter}");


        }
        else if (gradeInt >= 60)
        {
            gradeLetter = "D";
            Console.WriteLine($"Your grade is {gradeLetter}");


        }
        else if (gradeInt < 60)
        {
            gradeLetter = "F";
            Console.WriteLine($"Your grade is {gradeLetter}");


        }



        if (gradeInt > 70)
        {
            Console.WriteLine($"Your passed the class. ");
        }
        else
        {
            Console.WriteLine("Continue working on your classes.");
        }





    }
}