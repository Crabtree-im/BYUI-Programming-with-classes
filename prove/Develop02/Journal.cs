using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            File.WriteAllLines(filename, _entries.Select(entry => entry.ToFileFormat()));
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

        int totalWords = _entries.Sum(entry => CountWords(entry.GetResponse()));
        double averageWords = (double)totalWords / _entries.Count;
        List<int> moodRatings = _entries
            .Where(entry => entry.GetMoodRating() > 0)
            .Select(entry => entry.GetMoodRating())
            .ToList();

        Console.WriteLine($"Entries: {_entries.Count}");
        Console.WriteLine($"Total words: {totalWords}");
        Console.WriteLine($"Average words per entry: {averageWords:F1}");
        if (moodRatings.Count > 0)
        {
            Console.WriteLine($"Average recorded mood: {moodRatings.Average():F1}/5\n");
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
