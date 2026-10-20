# Scripture Memorizer - Design Submission
## CSE 210: Programming with Classes - Encapsulation Activity

---

## 1. Class Diagram Overview

```
┌─────────────────────────────────────────────────┐
│              Scripture                          │
├─────────────────────────────────────────────────┤
│ Attributes:                                     │
│  - _reference: Reference                        │
│  - _words: List<Word>                           │
├─────────────────────────────────────────────────┤
│ Methods:                                        │
│  + Scripture(reference, text)                   │
│  + HideWords(numToHide): void                   │
│  + GetRenderedText(): string                    │
│  + IsCompletelyHidden(): bool                   │
└─────────────────────────────────────────────────┘
            │ uses
            ▼
┌─────────────────────────────────────────────────┐
│              Reference                          │
├─────────────────────────────────────────────────┤
│ Attributes:                                     │
│  - _book: string                                │
│  - _chapter: int                                │
│  - _verse: int                                  │
│  - _endVerse: int (optional)                    │
├─────────────────────────────────────────────────┤
│ Methods:                                        │
│  + Reference(book, chapter, verse)              │
│  + Reference(book, chapter, verse, endVerse)    │
│  + GetRenderedText(): string                    │
└─────────────────────────────────────────────────┘

            Scripture uses many Words
            │
            ▼
┌─────────────────────────────────────────────────┐
│              Word                               │
├─────────────────────────────────────────────────┤
│ Attributes:                                     │
│  - _text: string                                │
│  - _isHidden: bool                              │
├─────────────────────────────────────────────────┤
│ Methods:                                        │
│  + Word(text)                                   │
│  + Hide(): void                                 │
│  + Show(): void                                 │
│  + IsHidden(): bool                             │
│  + GetRenderedText(): string                    │
└─────────────────────────────────────────────────┘
```

---

## 2. Class Details

### Class: Scripture

**Purpose:** Manages the scripture reference and text, handles hiding random words, and provides the current display state.

#### Attributes:
| Attribute | Type | Description |
|-----------|------|-------------|
| `_reference` | `Reference` | The book, chapter, and verse information |
| `_words` | `List<Word>` | Collection of Word objects representing each word in the scripture |

#### Behaviors/Methods:
| Method | Parameters | Return Type | Description |
|--------|-----------|------------|-------------|
| `Scripture()` | `Reference reference, string text` | Constructor | Initializes the scripture with a reference and text. Parses the text string to create individual Word objects and stores them in the _words list |
| `HideWords()` | `int numToHide` | `void` | Randomly selects the specified number of unhidden words and hides them |
| `GetRenderedText()` | None | `string` | Returns the scripture display with hidden words shown as underscores and visible words shown as their text |
| `IsCompletelyHidden()` | None | `bool` | Returns true if all words in the scripture are hidden, false otherwise |

#### Constructors:
```
Scripture(Reference reference, string text)
  - Accepts a Reference object and the scripture text as a string
  - Splits the text by spaces to create individual words
  - Creates a Word object for each word
  - Initializes all words as visible (not hidden)
  - Stores the reference and word list for later use
```

---

### Class: Reference

**Purpose:** Stores and displays scripture reference information (book, chapter, verse).

#### Attributes:
| Attribute | Type | Description |
|-----------|------|-------------|
| `_book` | `string` | The name of the book (e.g., "John", "Proverbs") |
| `_chapter` | `int` | The chapter number |
| `_verse` | `int` | The starting verse number |
| `_endVerse` | `int` | The ending verse number (for ranges like 3:5-6). Set to -1 or verse number if not a range |

#### Behaviors/Methods:
| Method | Parameters | Return Type | Description |
|--------|-----------|------------|-------------|
| `Reference()` | `string book, int chapter, int verse` | Constructor | Creates a reference for a single verse |
| `Reference()` | `string book, int chapter, int verse, int endVerse` | Constructor | Creates a reference for a range of verses |
| `GetRenderedText()` | None | `string` | Returns the formatted reference (e.g., "John 3:5" or "Proverbs 3:5-6") |

#### Constructors:
```
Reference(string book, int chapter, int verse)
  - Stores the book, chapter, and verse
  - Sets endVerse to the same value as verse (or -1) to indicate single verse

Reference(string book, int chapter, int verse, int endVerse)
  - Stores the book, chapter, and verse range
  - Allows for verses like "Proverbs 3:5-6"
```

---

### Class: Word

**Purpose:** Represents a single word and tracks whether it is hidden or visible.

#### Attributes:
| Attribute | Type | Description |
|-----------|------|-------------|
| `_text` | `string` | The actual text of the word |
| `_isHidden` | `bool` | Whether the word is currently hidden (true) or visible (false) |

#### Behaviors/Methods:
| Method | Parameters | Return Type | Description |
|--------|-----------|------------|-------------|
| `Word()` | `string text` | Constructor | Creates a word with the given text and sets it as visible by default |
| `Hide()` | None | `void` | Marks the word as hidden |
| `Show()` | None | `void` | Marks the word as visible |
| `IsHidden()` | None | `bool` | Returns whether the word is hidden |
| `GetRenderedText()` | None | `string` | Returns underscores if hidden, or the word text if visible |

#### Constructors:
```
Word(string text)
  - Stores the word text
  - Initializes _isHidden to false (word is visible by default)
```

---

## 3. Program Interaction Flow

```
┌────────────────────────────────────────────────────────────┐
│                  MAIN PROGRAM FLOW                         │
└────────────────────────────────────────────────────────────┘

1. INITIALIZATION
   ├─ Create Reference object
   │  └─ new Reference("John", 3, 5)
   ├─ Create Scripture object with Reference and text
   │  └─ new Scripture(reference, "In the beginning was the Word")
   │     └─ Scripture constructor splits text and creates Word objects
   └─ Display initial scripture

2. GAME LOOP
   ├─ Display current scripture rendering
   │  └─ scripture.GetRenderedText()
   │     └─ Calls GetRenderedText() on each Word
   ├─ Check if completely hidden
   │  └─ scripture.IsCompletelyHidden()
   ├─ Prompt user: "Press Enter to hide more words or type 'quit' to exit"
   ├─ User input handling:
   │  ├─ If user types "quit" → END PROGRAM
   │  └─ If user presses Enter → Hide words
   │      └─ scripture.HideWords(3) [or other number]
   │         └─ Randomly selects unhidden words and calls Hide() on each
   └─ Repeat loop

3. END CONDITIONS
   ├─ User types "quit" → Program ends
   └─ All words hidden → Program ends (game complete)
```

### Method Call Sequence Example:
```
1. user presses Enter
   ↓
2. scripture.HideWords(3)
   ├─ Randomly selects 3 unhidden Word objects from _words list
   ├─ Calls word1.Hide()
   ├─ Calls word2.Hide()
   └─ Calls word3.Hide()
   ↓
3. scripture.GetRenderedText()
   ├─ Calls _reference.GetRenderedText()
   │  └─ Returns "John 3:5"
   ├─ Iterates through _words list
   │  ├─ Calls word1.GetRenderedText() → returns "____" (hidden)
   │  ├─ Calls word2.GetRenderedText() → returns "the" (visible)
   │  └─ Calls word3.GetRenderedText() → returns "___" (hidden)
   └─ Returns "John 3:5\n____ the ___ beginning was the Word"
```

---

## 4. Design Rationale

### Encapsulation Principles Applied:
- **Private Attributes:** All member variables in each class are private (prefixed with `_`)
- **Getters:** Classes provide methods to retrieve data without modification
- **Setters:** Changes to state are controlled through specific methods (Hide(), Show())
- **Responsibility Separation:**
  - `Word` handles individual word state and rendering
  - `Scripture` manages multiple words and the overall scripture state
  - `Reference` manages reference information separately from scripture text

### Why This Design Works:
1. **Maintainability:** Each class has a single responsibility and can be modified independently
2. **Reusability:** Reference and Word classes could be used in other programs
3. **Extensibility:** Easy to add features like multiple scripture versions or persistent hidden state
4. **Testability:** Each class can be unit tested independently

---

## 5. Key Features

✓ **Classes:** Scripture, Reference, Word  
✓ **Scripture Behaviors:** HideWords, GetRenderedText, IsCompletelyHidden  
✓ **Scripture Attributes:** _reference, _words  
✓ **Reference Behaviors:** GetRenderedText, Constructors  
✓ **Reference Attributes:** _book, _chapter, _verse, _endVerse  
✓ **Word Behaviors:** Hide, Show, IsHidden, GetRenderedText  
✓ **Word Attributes:** _text, _isHidden  
✓ **Constructors:** All classes have appropriate constructors  
✓ **Interaction:** Flow diagram shows how methods interact  

---
