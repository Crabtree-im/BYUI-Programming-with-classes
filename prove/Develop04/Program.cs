using System;

// Mindfulness Program - Unit 04 Develop Activity
// 
// EXCEEDING REQUIREMENTS:
// 1. Enhanced Animations: The base Activity class includes two types of animations:
//    - A spinner animation (| / - \) that cycles through during pauses
//    - A countdown timer that displays remaining seconds
// 2. Extended Prompt Libraries: 
//    - ReflectingActivity includes 5 reflection prompts and 9 follow-up questions
//    - ListingActivity includes 7 diverse prompts covering different areas of strength
// 3. Robust Duration Timing: Using DateTime.Now with TotalSeconds provides accurate
//    timing that continues activities until the exact duration is reached, even if
//    the individual segments don't divide evenly into the total time
// 4. Clean Code Architecture: Proper encapsulation with private fields and protected
//    helper methods in the base class reduces code duplication across activities
// 5. User Experience Enhancements: Clear menu prompts, input validation on menu choice,
//    and consistent formatting across all activities

class Program
{
    static void Main(string[] args)
    {
        Activity current = null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice (1-4): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    current = new BreathingActivity();
                    current.Run();
                    break;
                case "2":
                    current = new ReflectingActivity();
                    current.Run();
                    break;
                case "3":
                    current = new ListingActivity();
                    current.Run();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }
}