using System;

class Program
{
    static void Main(string[] args)
    {
        int input = 0;

        Random randomGenerator = new Random();
        int MagicNumber = randomGenerator.Next(1, 101);

        while (input != MagicNumber)
        {
            Console.Write("What is your guess? ");
            input = int.Parse(Console.ReadLine());

            if (MagicNumber > input)
            {
                Console.WriteLine("Higher");
            }
            else if (MagicNumber < input)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }       
    }
}