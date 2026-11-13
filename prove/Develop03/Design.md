# Develop03: Scripture Memorizer - Design Submission

## CSE 210: Programming with Classes - Encapsulation Activity

---

## 1. Program Overview

### What is Scripture Memorizer?
The Scripture Memorizer program helps people practice memorizing Bible verses. It displays a scripture verse with some words hidden (replaced by dashes), and the user tries to recall what words are hidden. As they practice, they can reveal one hidden word at a time until they memorize the whole verse.

### How It Works
1. Program shows a scripture reference (like "John 3:16") and the verse text
2. Randomly hides some words so they appear as dashes
3. User can choose to reveal one random hidden word or quit
4. When all words are hidden, the user has memorized the verse and wins
5. User types "quit" to exit at any time

---

## 2. Class Diagram

### ASCII Class Diagram
```
┌─────────────────────────────────────┐
│           SCRIPTURE                 │
├─────────────────────────────────────┤
│ - reference: Reference              │
│ - words: List<Word>                 │
├─────────────────────────────────────┤
│ + Scripture(ref, text)              │
│ + HideRandomWords(count)            │
│ + GetDisplayText(): string          │
│ + IsCompletelyHidden(): bool        │
└─────────────────────────────────────┘
           ▲
           │ uses
           │
    ┌──────┴──────┐
    │             │
┌───────────┐  ┌──────────┐
│ REFERENCE │  │   WORD   │
├───────────┤  ├──────────┤
│ - book    │  │ - text   │
│ - chapter │  │ - hidden │
│ - verse   │  ├──────────┤
├───────────┤  │ + Word() │
│ + GetRef()│  │ + Hide() │
└───────────┘  │ + Show() │
               │ + IsHidden()
               │ + GetDisplay()
               └──────────┘
```

---

## 3. Class: Scripture

**Responsibility**: Manages the entire scripture verse, tracks all the words, and handles hiding/revealing words.

### Attributes (Data it needs to store):
| Attribute | Type | Description |
|-----------|------|-------------|
| `_reference` | `Reference` | The book, chapter, and verse reference (e.g., "John 3:16") |
| `_words` | `List<Word>` | All the individual words in the scripture verse |

### Methods (Things it can do):

| Method | Parameters | Return Type | What it does |
|--------|-----------|------------|-------------|
| `Scripture()` | `reference: Reference`, `text: string` | Constructor | Creates a Scripture with a reference and the full verse text. Splits the text into words and creates Word objects for each one. |
| `HideRandomWords()` | `count: int` | `void` | Randomly picks words and hides them (replaces them with dashes). Hides "count" number of words. |
| `GetDisplayText()` | none | `string` | Returns the verse text with hidden words shown as dashes and visible words shown as normal text. |
| `IsCompletelyHidden()` | none | `bool` | Returns true if all words are hidden, false if any word is still visible. |
| `GetReference()` | none | `Reference` | Returns the Reference object so we can display the scripture reference. |

### Why these methods?
- The constructor sets everything up at the start
- HideRandomWords() is how we make the game harder
- GetDisplayText() is what the user sees on screen
- IsCompletelyHidden() tells us when the game is won
- GetReference() lets us show "John 3:16" at the top

---

## 4. Class: Reference

**Responsibility**: Keeps track of which scripture is being memorized (book, chapter, verse).

### Attributes (Data it needs to store):
| Attribute | Type | Description |
|-----------|------|-------------|
| `_book` | `string` | The name of the book (e.g., "John") |
| `_chapter` | `int` | The chapter number (e.g., 3) |
| `_verse` | `int` | The verse number or starting verse (e.g., 16) |
| `_endVerse` | `int` | The ending verse for ranges like "3:5-6" (optional, 0 if single verse) |

### Methods (Things it can do):

| Method | Parameters | Return Type | What it does |
|--------|-----------|------------|-------------|
| `Reference()` | `book: string`, `chapter: int`, `verse: int` | Constructor | Creates a reference for a single verse like John 3:16 |
| `Reference()` | `book: string`, `chapter: int`, `verse: int`, `endVerse: int` | Constructor | Creates a reference for a verse range like Proverbs 3:5-6 |
| `GetDisplayText()` | none | `string` | Returns the formatted reference like "John 3:16" or "Proverbs 3:5-6" |

### Why these methods?
- Two constructors because some verses are single (John 3:16) and some are ranges (Proverbs 3:5-6)
- GetDisplayText() shows it nicely at the top of the screen

---

## 5. Class: Word

**Responsibility**: Represents a single word and keeps track of whether it's hidden or visible.

### Attributes (Data it needs to store):
| Attribute | Type | Description |
|-----------|------|-------------|
| `_text` | `string` | The actual word text (e.g., "God", "loved", "world") |
| `_isHidden` | `bool` | Whether this word is currently hidden (true) or visible (false) |

### Methods (Things it can do):

| Method | Parameters | Return Type | What it does |
|--------|-----------|------------|-------------|
| `Word()` | `text: string` | Constructor | Creates a word with the given text. The word starts visible (not hidden). |
| `Hide()` | none | `void` | Makes this word hidden |
| `Show()` | none | `void` | Makes this word visible |
| `IsHidden()` | none | `bool` | Returns true if the word is hidden, false if visible |
| `GetDisplayText()` | none | `string` | Returns the word if visible, or dashes if hidden. E.g., "God" or "___" |

### Why these methods?
- The constructor sets up the word initially visible
- Hide() and Show() change the word's state
- IsHidden() lets Scripture know if a word is hidden
- GetDisplayText() returns what the user should see on screen

---

## 6. How It All Works Together (Interaction)

### When the program starts:
1. `Program.cs` creates a `Reference` (e.g., "John 3:16")
2. `Program.cs` creates a `Scripture` with the Reference and the verse text
3. `Scripture` constructor splits the text and creates `Word` objects for each word

### When the user wants to reveal a word:
1. `Program.cs` calls `scripture.HideRandomWords(1)` to hide a new word
2. `Scripture` picks a random word from its word list and calls `Hide()` on it
3. `Program.cs` calls `scripture.GetDisplayText()` to show the current state
4. `Scripture` asks each `Word` to return its display text (real word or dashes)

### Checking if the game is won:
1. `Program.cs` calls `scripture.IsCompletelyHidden()`
2. `Scripture` checks each `Word` to see if all are hidden
3. If all hidden, return true and the game ends

---

## 7. Design Decisions & Why

### Why separate Word, Reference, and Scripture?
- **Word** only cares about one word and whether it's hidden
- **Reference** only cares about book/chapter/verse
- **Scripture** brings them together and manages the whole game
- This makes each class simple and easy to understand

### Why use getters and setters?
- Instead of letting other code directly change `_isHidden`, the `Word` class provides `Hide()` and `Show()`
- This makes sure words are always in a valid state (always either hidden or shown)
- If we need to change how hiding works later, we only change the Word class

### Why store Word objects instead of just the text?
- Each word needs to track its own hidden/visible state
- By making a Word class, each word can manage its own data
- This is much cleaner than having parallel lists of text and hidden status

---

## 8. Verification Against Requirements

✓ Class diagram includes Scripture, Reference, and Word classes  
✓ Scripture class has all methods needed for the game  
✓ Reference class stores book, chapter, verse information  
✓ Word class stores text and hidden state  
✓ All getters and setters used for encapsulation  
✓ Constructors defined for each class  
✓ Interaction diagram shows how classes work together  
✓ Follows naming conventions: `_camelCase` for fields, `PascalCase` for classes/methods  
