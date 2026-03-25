using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availableQuestions;
    private Random _random;

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

        _random = new Random();
        _availableQuestions = new List<string>();
        
        // Initialize available questions with all questions
        ResetAvailableQuestions();
    }

    private void ResetAvailableQuestions()
    {
        _availableQuestions.Clear();
        foreach (string question in _questions)
        {
            _availableQuestions.Add(question);
        }
    }

    private string GetRandomQuestion()
    {
        // If no questions are available, reset the list
        if (_availableQuestions.Count == 0)
        {
            ResetAvailableQuestions();
        }

        // Pick a random question from the available list
        int index = _random.Next(_availableQuestions.Count);
        string selectedQuestion = _availableQuestions[index];
        
        // Remove the selected question so it won't be used again until reset
        _availableQuestions.RemoveAt(index);
        
        return selectedQuestion;
    }

    protected override void RunActivity()
    {
        int promptIndex = _random.Next(_prompts.Count);
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {_prompts[promptIndex]} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
    }
}