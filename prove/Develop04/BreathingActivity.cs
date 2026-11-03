using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("Breathe in...");
            PauseWithCountdown(4);
            Console.WriteLine();
            
            Console.Write("Breathe out...");
            PauseWithCountdown(4);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
}
