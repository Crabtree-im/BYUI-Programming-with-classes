using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this year?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are some of your proudest accomplishments?",
            "What are things you're grateful for?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---\n");
        Console.WriteLine("You may begin in:");
        PauseWithCountdown(5);
        
        int count = GetListFromUser(_duration);
        
        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private int GetListFromUser(int durationSeconds)
    {
        int count = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < durationSeconds)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                count++;
            }
        }

        return count;
    }
}
