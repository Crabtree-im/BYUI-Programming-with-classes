using System;

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