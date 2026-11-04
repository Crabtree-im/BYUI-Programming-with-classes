using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.\n");
            return;
        }

        try
        {
            List<string> linesToWrite = new List<string>();
            foreach (Entry entry in _entries)
            {
                linesToWrite.Add(entry.ToFileFormat());
            }
            File.WriteAllLines(filename, linesToWrite);
            Console.WriteLine($"Journal saved to {filename}\n");
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException or NotSupportedException)
        {
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.\n");
            return;
        }

        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            foreach (string line in File.ReadAllLines(filename))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    loadedEntries.Add(Entry.FromFileFormat(line));
                }
            }

            _entries.Clear();
            _entries.AddRange(loadedEntries);
            Console.WriteLine($"Journal loaded from {filename}\n");
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException or NotSupportedException or FormatException)
        {
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
    }

    public void DisplayStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to summarize yet.\n");
            return;
        }

        int totalWords = 0;
        foreach (Entry entry in _entries)
        {
            totalWords += CountWords(entry.GetResponse());
        }

        double averageWords = (double)totalWords / _entries.Count;

        List<int> moodRatings = new List<int>();
        foreach (Entry entry in _entries)
        {
            if (entry.GetMoodRating() > 0)
            {
                moodRatings.Add(entry.GetMoodRating());
            }
        }

        Console.WriteLine($"Entries: {_entries.Count}");
        Console.WriteLine($"Total words: {totalWords}");
        Console.WriteLine($"Average words per entry: {averageWords:F1}");
        if (moodRatings.Count > 0)
        {
            double averageMood = 0;
            foreach (int mood in moodRatings)
            {
                averageMood += mood;
            }
            averageMood /= moodRatings.Count;
            Console.WriteLine($"Average recorded mood: {averageMood:F1}/5\n");
        }
        else
        {
            Console.WriteLine("No mood ratings have been recorded yet.\n");
        }
    }

    private static int CountWords(string text)
    {
        return text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
