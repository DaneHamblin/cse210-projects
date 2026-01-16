using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        string username = PromptUserName();
        int UserNumber = AskUserNumber();

        int squaredNumber = SquareNumber(UserNumber);

        int BirthYear;
        AskBirthYear(out BirthYear);

        DisplayInfo(username, squaredNumber, BirthYear);
    }
    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }
    static int AskUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static void AskBirthYear(out int birthYear)
    {
        Console.Write($"Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());

    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayInfo(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} years old this year.");
    }
}