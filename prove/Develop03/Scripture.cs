using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the text by spaces and create Word objects
        string[] wordTexts = text.Split(' ');
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(_words.Count);
        _words[randomIndex].Hide();
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        
        string scriptureText = string.Join(" ", displayWords);
        
        return $"{referenceText} {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
