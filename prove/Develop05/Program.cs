using System;
using System.Collections.Generic;

class Program
{
    private static GoalManager _goalManager;

    static void Main(string[] args)
    {
        _goalManager = new GoalManager();
        _goalManager.LoadGoals();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine($"Current Score: {_goalManager.GetScore()} points");
            Console.WriteLine("========================================");
            
            int choice = DisplayMenu();

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    RecordGoalEvent();
                    break;
                case 3:
                    ListGoals();
                    break;
                case 4:
                    ViewScore();
                    break;
                case 5:
                    SaveAndQuit();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static int DisplayMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Record Goal Event");
        Console.WriteLine("3. List All Goals");
        Console.WriteLine("4. View Score");
        Console.WriteLine("5. Save and Quit");
        Console.Write("Enter your choice (1-5): ");
        
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }
        return 0;
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal (complete once)");
        Console.WriteLine("2. Eternal Goal (never complete)");
        Console.WriteLine("3. Checklist Goal (complete multiple times)");
        Console.Write("Enter your choice (1-3): ");

        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        Goal newGoal = null;

        switch (type)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter target amount to complete: ");
                if (!int.TryParse(Console.ReadLine(), out int targetAmount))
                {
                    Console.WriteLine("Invalid target amount.");
                    return;
                }

                Console.Write("Enter bonus points when completed: ");
                if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                {
                    Console.WriteLine("Invalid bonus points.");
                    return;
                }

                newGoal = new ChecklistGoal(name, description, points, targetAmount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        if (newGoal != null)
        {
            _goalManager.AddGoal(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    private static void RecordGoalEvent()
    {
        List<Goal> goals = _goalManager.GetGoals();

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("Enter goal number: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        int pointsEarned = _goalManager.RecordGoalEvent(choice - 1);
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
    }

    private static void ListGoals()
    {
        List<Goal> goals = _goalManager.GetGoals();

        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create a goal to get started!");
            return;
        }

        Console.WriteLine("\n========== Your Goals ==========");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDisplayString()}");
        }
        Console.WriteLine("================================");
    }

    private static void ViewScore()
    {
        Console.WriteLine($"\n=== Your Score ===");
        Console.WriteLine($"Total Points: {_goalManager.GetScore()}");
        Console.WriteLine("==================");
    }

    private static void SaveAndQuit()
    {
        _goalManager.SaveGoals();
        Console.WriteLine("Goals and score saved. Thank you for using Eternal Quest!");
    }
}
