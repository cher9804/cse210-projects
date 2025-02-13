using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment test = new Assignment("Cristian", "Tested");
        Console.WriteLine(test.GetSummary());

        MathAssignment test1 = new MathAssignment("Cristian Hernandez", "Testedeed", "7.9", "10 - 34");
        Console.WriteLine(test1.GetHomeworkList());

        WritingAssignment test2 = new WritingAssignment("Cristian", "Test", "Title goes here");
        Console.WriteLine(test2.GetWritingInformation());

    }
}