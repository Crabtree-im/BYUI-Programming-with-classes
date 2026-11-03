using System;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"Description: {_description}\n");
        Console.Write("How many seconds would you like for this session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready to begin...");
        Pause(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        Pause(2);
        Console.WriteLine($"You have completed another {_name} Activity that lasted {_duration} seconds.");
        Pause(3);
    }

    protected void Pause()
    {
        Pause(1);
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }
}
