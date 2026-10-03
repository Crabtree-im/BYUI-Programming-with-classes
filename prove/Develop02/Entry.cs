using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToShortDateString();
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetDate()
    {
        return _date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        // Using ~|~ as separator to avoid conflicts with user content
        return $"{_date}~|~{_prompt}~|~{_response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length == 3)
        {
            Entry entry = new Entry(parts[1], parts[2]);
            entry._date = parts[0];
            return entry;
        }
        return null;
    }
}
