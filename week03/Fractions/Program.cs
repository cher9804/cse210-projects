using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(3, 4);
        Fraction fraction3 = new Fraction(3, 4);

        double frac2 = fraction2.GetDecimalValue();
        Console.WriteLine($"{frac2:F2}");

        string frac2s = fraction2.GetFractionString();
        Console.WriteLine(frac2s);

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());






        // int frac1top = fraction1.GetTop();
        // Console.WriteLine(frac1top);

        // int frac2top = fraction2.GetTop();
        // Console.WriteLine(frac2top);

        // int frac3top = fraction3.GetTop();
        // Console.WriteLine(frac3top);

        // int frac1bot = fraction1.GetBottom();
        // Console.WriteLine(frac1bot);

        // int frac2bot = fraction2.GetBottom();
        // Console.WriteLine(frac2bot);

        // int frac3bot = fraction3.GetBottom();
        // Console.WriteLine(frac3bot);








    }
}