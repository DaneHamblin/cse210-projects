using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("=== Personal Journal Program ===");
        Console.WriteLine("Welcome to your digital journal!\n");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for journaling. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nPlease choose an option:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    static void WriteNewEntry(Journal journal)
    {
        Console.WriteLine("\n--- New Journal Entry ---");
        
        // Get current date
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        
        // Get random prompt
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        
        // Get user response
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        // Add entry to journal
        journal.AddEntry(currentDate, prompt, response);
        Console.WriteLine("Entry added successfully!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(filename))
        {
            // Add .txt extension if it's not there
            if (!filename.Contains("."))
            {
                filename += ".txt";
            }
            journal.SaveToFile(filename);
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.LoadFromFile(filename);
        }
    }
}