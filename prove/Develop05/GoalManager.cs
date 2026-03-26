using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit\n");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("\nGoodbye! Keep working on your Eternal Quest!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal\n");
        Console.Write("Which type of goal would you like to create? ");
        
        string typeChoice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (typeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus points for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"\nGoal '{name}' has been created successfully!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

private void ListGoalDetails()
{
    Console.Clear();
    Console.WriteLine("The goals are:\n");
    
    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals have been created yet.");
    }
    else
    {
        List<Goal> activeGoals = new List<Goal>();
        List<Goal> completedGoals = new List<Goal>();
        
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals.Add(goal);
            }
            else
            {
                activeGoals.Add(goal);
            }
        }
        
        if (activeGoals.Count > 0)
        {
            Console.WriteLine("--- Active Goals ---");
            int displayNumber = 1;
            foreach (Goal goal in activeGoals)
            {
                Console.WriteLine($"{displayNumber}. {goal.GetDetailsString()}");
                displayNumber++;
            }
            Console.WriteLine();
        }
        
        if (completedGoals.Count > 0)
        {
            Console.WriteLine("--- Completed Goals ---");
            int displayNumber = 1;
            foreach (Goal goal in completedGoals)
            {
                Console.WriteLine($"{displayNumber}. {goal.GetDetailsString()}");
                displayNumber++;
            }
            Console.WriteLine();
        }
        
        if (activeGoals.Count > 0 && completedGoals.Count == 0)
        {
            Console.WriteLine("No completed goals yet. Keep working on your goals!");
        }
        else if (activeGoals.Count == 0 && completedGoals.Count > 0)
        {
            Console.WriteLine("All goals are completed! Great job! Create some new goals to keep progressing.");
        }
    }
    
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

    private void SaveGoals()
    {
        Console.Clear();
        string filename = "goals.txt";
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine($"Goals have been saved to {filename}");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void LoadGoals()
    {
        Console.Clear();
        string filename = "goals.txt";
        
        if (!File.Exists(filename))
        {
            Console.WriteLine($"No saved file found named {filename}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        
        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);
            _goals.Clear();
            
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');
                
                Goal goal = null;
                
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5]));
                        break;
                }
                
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
            
            Console.WriteLine($"Goals have been loaded from {filename}");
            Console.WriteLine($"You have {_score} points");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void RecordEvent()
    {
        Console.Clear();
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet. Please create a goal first.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine("The goals are:\n");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
        
        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        
        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();
            
            int pointsEarned = selectedGoal.GetPoints();
            _score += pointsEarned;
            
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            
            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonusPoints();
                _score += bonus;
                Console.WriteLine($"Bonus! You earned an additional {bonus} points for completing the checklist goal!");
            }
            
            Console.WriteLine($"You now have {_score} points.");
            
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine($"\nGreat job completing the goal: {selectedGoal.GetShortName()}");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}