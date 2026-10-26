using System;
using System.Collections.Generic;

class Program
{
    /*
     * EXCEEDING REQUIREMENTS:
     * 
     * 1. Multi-Scripture Library: Instead of working with just a single scripture,
     *    this program loads and manages multiple scriptures from a collection.
     *    The user can choose which scripture to practice with, allowing for a more
     *    robust learning experience.
     * 
     * 2. Scripture Selection Menu: Added an interactive menu that displays available
     *    scriptures and allows the user to select which one to memorize. This provides
     *    a better user experience and makes the program more flexible.
     * 
     * 3. Word Count Tracking: The program displays how many words are visible vs hidden,
     *    giving users feedback on their progress through the memorization exercise.
     * 
     * 4. Improved Randomization: Enhanced the random word selection to avoid selecting
     *    already hidden words, making the progression more logical (though the core
     *    requirement allows selecting any word).
     */

    static void Main(string[] args)
    {
        List<Scripture> scriptures = CreateScriptureLibrary();
        
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine();
        
        while (true)
        {
            Scripture selectedScripture = SelectScripture(scriptures);
            PracticeScripture(selectedScripture);
            
            Console.WriteLine();
            Console.Write("Practice another scripture? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response != "yes" && response != "y")
            {
                Console.WriteLine("Thank you for practicing! Goodbye!");
                break;
            }
            Console.Clear();
        }
    }

    static List<Scripture> CreateScriptureLibrary()
    {
        List<Scripture> scriptures = new List<Scripture>();
        
        scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"
        ));
        
        scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight"
        ));
        
        scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1, 6),
            "The Lord is my shepherd I shall not be in want He makes me lie down in green pastures He leads me beside quiet waters He restores my soul He guides me in paths of righteousness for his name sake"
        ));
        
        scriptures.Add(new Scripture(
            new Reference("1 Corinthians", 13, 4, 7),
            "Love is patient love is kind It does not envy it does not boast it is not proud It does not dishonor others it is not self seeking it is not easily angered it keeps no record of wrongs Love does not delight in evil but rejoices with the truth It always protects always trusts always hopes always perseveres"
        ));
        
        return scriptures;
    }

    static Scripture SelectScripture(List<Scripture> scriptures)
    {
        Console.WriteLine("Available Scriptures:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText()}");
        }
        
        Console.Write($"Select a scripture (1-{scriptures.Count}): ");
        
        int selection = 0;
        while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > scriptures.Count)
        {
            Console.Write($"Invalid selection. Please enter a number between 1 and {scriptures.Count}: ");
        }
        
        return scriptures[selection - 1];
    }

    static void PracticeScripture(Scripture scripture)
    {
        Console.Clear();
        
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words (or type 'quit' to exit): ");
            
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Exiting scripture practice.");
                return;
            }
            
            scripture.HideRandomWord();
            Console.Clear();
        }
        
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("All words are hidden! You've completed this scripture!");
    }
}