using System;
using System.Collections.Generic;
using System.Text;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;
    private int _moodRating;

    public Entry(string prompt, string response, int moodRating)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToShortDateString();
        _moodRating = moodRating;
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

    public int GetMoodRating()
    {
        return _moodRating;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine(_moodRating == 0 ? "Mood: Not recorded" : $"Mood: {_moodRating}/5");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return string.Join(",", EscapeCsvField(_date), EscapeCsvField(_prompt),
            EscapeCsvField(_response), EscapeCsvField(_moodRating == 0 ? "" : _moodRating.ToString()));
    }

    public static Entry FromFileFormat(string line)
    {
        int legacySeparator = line.IndexOf("~|~", StringComparison.Ordinal);
        int firstCsvComma = line.IndexOf(',');
        if (legacySeparator >= 0 && (firstCsvComma < 0 || legacySeparator < firstCsvComma))
        {
            string[] legacyParts = line.Split("~|~");
            if (legacyParts.Length != 3)
            {
                throw new FormatException("The legacy journal entry does not have three fields.");
            }

            Entry legacyEntry = new Entry(legacyParts[1], legacyParts[2], 0);
            legacyEntry._date = legacyParts[0];
            return legacyEntry;
        }

        List<string> fields = ParseCsvRecord(line);
        int moodRating = 0;
        if (fields.Count != 4 ||
            (fields[3] != "" &&
             (!int.TryParse(fields[3], out moodRating) || moodRating < 1 || moodRating > 5)))
        {
            throw new FormatException("A journal entry must have four fields and a mood rating from 1 to 5, if provided.");
        }

        Entry entry = new Entry(fields[1], fields[2], moodRating);
        entry._date = fields[0];
        return entry;
    }

    private static string EscapeCsvField(string field)
    {
        if (field.Contains(',') || field.Contains('"') || field.Contains('\r') || field.Contains('\n'))
        {
            return $"\"{field.Replace("\"", "\"\"")}\"";
        }

        return field;
    }

    private static List<string> ParseCsvRecord(string record)
    {
        List<string> fields = new List<string>();
        StringBuilder field = new StringBuilder();
        bool insideQuotes = false;
        bool quoteClosed = false;

        for (int index = 0; index < record.Length; index++)
        {
            char character = record[index];

            if (insideQuotes)
            {
                if (character == '"' && index + 1 < record.Length && record[index + 1] == '"')
                {
                    field.Append('"');
                    index++;
                }
                else if (character == '"')
                {
                    insideQuotes = false;
                    quoteClosed = true;
                }
                else
                {
                    field.Append(character);
                }

                continue;
            }

            if (character == ',')
            {
                fields.Add(field.ToString());
                field.Clear();
                quoteClosed = false;
            }
            else if (character == '"' && field.Length == 0 && !quoteClosed)
            {
                insideQuotes = true;
            }
            else if (quoteClosed)
            {
                throw new FormatException("Unexpected characters after a quoted CSV field.");
            }
            else
            {
                field.Append(character);
            }
        }

        if (insideQuotes)
        {
            throw new FormatException("A quoted CSV field was not closed.");
        }

        fields.Add(field.ToString());
        return fields;
    }
}
