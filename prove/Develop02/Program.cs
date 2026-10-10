using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements:
        // - Journal class manages entries and file I/O
        // - Entry class stores prompt, response, and date
        // - PromptGenerator class provides random prompts
        // - Menu-driven interface for user interaction
        // 
        // Abstraction Demonstrated:
        // - Each class has well-defined responsibilities
        // - Entry handles its own display and file formatting
        // - Journal handles collection management and file operations
        // - PromptGenerator abstracts prompt retrieval
        // - Program.cs remains simple, delegating to appropriate classes
        //
        // Creativity beyond the core requirements:
        // - New entries include a 1-5 mood rating to encourage reflection beyond
        //   the written response; older entries load with mood unrecorded.
        // - Journal statistics summarize word count and recorded mood trends.
        // - CSV quoting preserves commas and quotation marks and can be opened in
        //   spreadsheet software. Older entries without a mood rating still load.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== Journal Program ===");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. View journal statistics");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                running = false;
                continue;
            }

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    journal.DisplayStatistics();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        if (response == null)
        {
            Console.WriteLine("Input ended. Entry was not added.\n");
            return;
        }

        if (!TryReadMoodRating(out int moodRating))
        {
            Console.WriteLine("Input ended. Entry was not added.\n");
            return;
        }

        Entry entry = new Entry(prompt, response, moodRating);
        journal.AddEntry(entry);
        Console.WriteLine("Entry saved!\n");
    }

    static bool TryReadMoodRating(out int moodRating)
    {
        while (true)
        {
            Console.Write("Rate your mood today from 1 (low) to 5 (high): ");
            string input = Console.ReadLine();

            if (input == null)
            {
                moodRating = 0;
                return false;
            }

            if (int.TryParse(input, out moodRating) && moodRating >= 1 && moodRating <= 5)
            {
                return true;
            }

            Console.WriteLine("Please enter a whole number from 1 to 5.");
        }
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save to: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}