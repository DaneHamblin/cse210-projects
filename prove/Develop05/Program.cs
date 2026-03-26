using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("This program will help you track your goals and earn points.\n");
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey();
        
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}