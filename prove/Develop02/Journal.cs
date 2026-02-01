using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Needed variables
    private List<Entry> entries;
    private List<string> prompts;

    // Constructing object
    public Journal()
    {
        entries = new List<Entry>();
        InitializePrompts();
    }

    // List of prompts
    private void InitializePrompts()
    {
        prompts = new List<string>
        {
            "Who did I enjoy seeing the most today?",
            "What made my day today?",
            "Did I do anything cool today? How did I do it?",
            "If I was to describe my day today with one word what would it be?",
            "If I had one thing I could do over today, what would it be?",
            "Did anything go wrong today? Was there anything you could do in the future to prevent that?",
            "What lesson did I learn today?",
            "What made me smile today?",
            "What challenged me the most today?",
            "What would I like to accomplish tomorrow?"
        };
    }

    // add a new entry
    public void AddEntry(string date, string prompt, string response)
    {
        Entry newEntry = new Entry(date, prompt, response);
        entries.Add(newEntry);
    }

    // display all entries
    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===\n");
        foreach (Entry entry in entries)
        {
            entry.Display();
            Console.WriteLine("------------------------");
        }
    }

    // get a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    // Method to save journal to file
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.FormatForFile());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Method to load journal from file
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    loadedEntries.Add(entry);
                }
            }

            entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}