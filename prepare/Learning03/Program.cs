using System;

class Program
{
    static void Main(string[] args)
    {
        // Test constructors and representations
        Console.WriteLine("Testing Constructors and Representations:");
        Console.WriteLine("----------------------------------------");
        
        Fraction f1 = new Fraction();         // 1/1
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine();

        Fraction f2 = new Fraction(5);        // 5/1
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine();

        Fraction f3 = new Fraction(3, 4);     // 3/4
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine();

        Fraction f4 = new Fraction(1, 3);     // 1/3
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        Console.WriteLine();

        // Test getters and setters
        Console.WriteLine("Testing Getters and Setters:");
        Console.WriteLine("---------------------------");
        
        Fraction testFraction = new Fraction(2, 3);
        Console.WriteLine($"Original: {testFraction.GetFractionString()}");
        
        // Use setters to change values
        testFraction.SetTop(7);
        testFraction.SetBottom(8);
        
        // Use getters to retrieve new values
        Console.WriteLine($"New top: {testFraction.GetTop()}");
        Console.WriteLine($"New bottom: {testFraction.GetBottom()}");
        Console.WriteLine($"New fraction: {testFraction.GetFractionString()}");
        Console.WriteLine($"New decimal: {testFraction.GetDecimalValue()}");
        Console.WriteLine();

        // Practice using Fraction class with random numbers
        Console.WriteLine("Practice with Random Fractions:");
        Console.WriteLine("-------------------------------");
        
        Random random = new Random();
        Fraction randomFraction = new Fraction();
        
        for (int i = 0; i < 20; i++)
        {
            int topValue = random.Next(1, 11);     // Random number 1-10
            int bottomValue = random.Next(1, 11);  // Random number 1-10
            
            randomFraction.SetTop(topValue);
            randomFraction.SetBottom(bottomValue);
            
            Console.Write($"Fraction {i + 1}: ");
            Console.Write($"string: {randomFraction.GetFractionString()} ");
            Console.WriteLine($"Number: {randomFraction.GetDecimalValue():F3}");
        }
    }
}