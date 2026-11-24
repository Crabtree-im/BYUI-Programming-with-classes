using System;
using System.Collections.Generic;

// ETERNAL QUEST PROGRAM - EXCEEDS REQUIREMENTS
// 
// This program demonstrates polymorphism through a goal-tracking system with 
// gamification features that exceed the core requirements:
//
// ENHANCEMENTS BEYOND CORE REQUIREMENTS:
// 1. PERSISTENT SESSION DATA: The program automatically saves all goals and 
//    the user's total score to a file (goals.txt) and loads them on startup.
//    This allows users to continue their quest across multiple sessions without
//    losing progress. The save/load functionality uses a custom serialization
//    format with polymorphic deserialization.
//
// 2. AUTOMATIC BONUS CALCULATION: ChecklistGoal automatically calculates and 
//    awards bonus points when the target is reached. Users see immediate 
//    feedback showing both the base points and bonus points in the same message.
//
// 3. VISUAL STATUS INDICATORS: The program uses checkbox notation ([X] and [ ])
//    to visually indicate goal completion status. For checklist goals, it shows
//    progress as "Completed X/Y times" for intuitive progress tracking.
//
// 4. COMPREHENSIVE USER INTERFACE: The menu-driven interface provides clear
//    options and feedback at every step. Score is displayed in a banner at the
//    top of each screen for constant visibility. Users see congratulatory
//    messages with specific point values when recording achievements.
//
// 5. POLYMORPHIC PERSISTENCE: The goal-loading system demonstrates polymorphism
//    by using a factory pattern in GoalManager.CreateGoalFromString() that
//    correctly deserializes each goal type and restores its complete state.
//
// DESIGN PRINCIPLES DEMONSTRATED:
// - Inheritance: All goal types inherit from abstract Goal base class
// - Polymorphism: Each goal type overrides RecordEvent(), IsComplete(), and
//   GetDisplayString() with type-specific behavior
// - Encapsulation: All data members are private/protected; access is controlled
//   through public methods
// - Abstraction: The base Goal class defines the interface; concrete types
//   implement specific behaviors

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
