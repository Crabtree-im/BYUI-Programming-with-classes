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
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();

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

        Entry entry = new Entry(prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Entry saved!\n");
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