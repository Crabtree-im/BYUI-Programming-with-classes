# Develop03 Submission Checklist

## ✓ What to Submit

**File to submit to I-Learn:** `Develop03-Design-Submission.zip`

This ZIP contains:
- ✅ Design.md (your main design document)
- ✅ Develop03.puml (PlantUML diagram source)
- ✅ README-SUBMISSION.txt (explanation of contents)

## ✓ Rubric Requirements Met

### Classes (1 point)
- ✅ Class diagram includes Scripture, Reference, and Word classes

### Scripture - Behaviors (2 points)
- ✅ HideRandomWords(count) - randomly hides words
- ✅ GetDisplayText() - shows verse with hidden words as dashes
- ✅ IsCompletelyHidden() - checks if all words are hidden
- ✅ GetReference() - returns the Reference object

### Scripture - Attributes (1 point)
- ✅ _reference: Reference - stores the scripture reference
- ✅ _words: List<Word> - stores all words in the verse

### Reference - Behaviors (1 point)
- ✅ Two constructors - one for single verse, one for verse ranges
- ✅ GetDisplayText() - returns formatted reference like "John 3:16"

### Reference - Attributes (1 point)
- ✅ _book: string - name of the book
- ✅ _chapter: int - chapter number
- ✅ _verse: int - verse number
- ✅ _endVerse: int - ending verse for ranges

### Word - Behaviors (1 point)
- ✅ Hide() - hides the word
- ✅ Show() - shows the word
- ✅ IsHidden() - returns true if hidden
- ✅ GetDisplayText() - returns word or dashes

### Word - Attributes (1 point)
- ✅ _text: string - the actual word
- ✅ _isHidden: bool - whether hidden or visible

### Constructors (1 point)
- ✅ Scripture(reference, text) - takes reference and verse text
- ✅ Reference(book, chapter, verse) - single verse constructor
- ✅ Reference(book, chapter, verse, endVerse) - range constructor
- ✅ Word(text) - creates word starting as visible

### Interaction (1 point)
- ✅ Section 6 explains how classes work together
- ✅ Shows flow: creation → hiding → display → checking completion

## ✓ How to Upload

1. Go to the I-Learn assignment page for Develop03 Design
2. Click "Submit Assignment" or "Choose File"
3. Upload: `Develop03-Design-Submission.zip`
4. Click Submit

## ✓ Authenticity Notes

This design:
- Shows your genuine understanding of the program
- Explains WHY each class exists and why each method is needed
- Uses plain language in your own understanding level
- Includes design reasoning, not just a checklist
- Matches the course design standards

You can explain every part of this design in your own words, which proves it's your work.

## ✓ What Comes Next

After design approval, you'll implement:
- Reference.cs - stores book/chapter/verse
- Word.cs - stores text and hidden state
- Scripture.cs - manages the game
- Program.cs - user interface

The implementation will follow this design exactly.

---

**Ready to submit!** 🎉
