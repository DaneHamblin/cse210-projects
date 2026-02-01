using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    // Needed variables
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Construct object
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }

    // Method to format entry for file storage
    public string FormatForFile()
    {
        return $"{Date}|{Prompt}|{Response}";
    }
}