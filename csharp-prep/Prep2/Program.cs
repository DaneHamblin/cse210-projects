using System;
using System.Net.Security;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hello, please enter your grade percentage to receive a letter grade. ");
        string input = Console.ReadLine();

        if (float.TryParse(input, out float grade_percentage))
            {
                Console.WriteLine($"You entered: {grade_percentage}%");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        if (grade_percentage >= 90)
            {
                Console.Write("You got an A! ");
            }
            else if (grade_percentage >= 80)
                {
                    Console.Write("You got a B, ");
                }
                else if (grade_percentage >= 70)
                    {
                        Console.Write("You got a C, ");
                    }
                    else if (grade_percentage >= 60)
                        {
                            Console.Write("You got a D, ");
                        }
                        else if (grade_percentage < 60)
                            {
                                Console.Write("You got an F, ");
                            }
        if (grade_percentage >= 70)
            {
                Console.Write("You Pass!");
            }
            else if (grade_percentage <70)
                {
                    Console.Write("You Fail.");
                }
    }
}