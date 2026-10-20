using System;

class Program
{
    static void Main(string[] args)
    {
        // Test constructors
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test getters and setters
        Fraction f5 = new Fraction();
        f5.SetTop(5);
        f5.SetBottom(6);
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine($"Top: {f5.GetTop()}, Bottom: {f5.GetBottom()}");
        Console.WriteLine(f5.GetDecimalValue());

        // Practice with random fractions
        Random random = new Random();
        Fraction randomFraction = new Fraction();
        for (int i = 0; i < 20; i++)
        {
            randomFraction.SetTop(random.Next(1, 11));
            randomFraction.SetBottom(random.Next(1, 11));
            Console.WriteLine(randomFraction.GetFractionString() + " = " + randomFraction.GetDecimalValue());
        }
    }
}