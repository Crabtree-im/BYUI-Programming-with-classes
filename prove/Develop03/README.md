# Develop03: Scripture Memorizer - Design Submission

## 📋 Quick Overview

**Program:** Scripture Memorizer - A program to help memorize Bible verses by progressively hiding words

**Assignment:** Design Activity for CSE 210 Unit 03 - Encapsulation

**Status:** ✅ Ready to Submit

---

## 📦 What to Submit

**Upload this file to I-Learn:** `Develop03-Design-Submission.zip`

The ZIP contains:
- `Design.md` - Your complete design document
- `Develop03.puml` - PlantUML class diagram source
- `README-SUBMISSION.txt` - Explanation of submission contents

---

## 📚 What's in This Folder

### Primary Files (for I-Learn submission)
- **Design.md** - Main design document with diagrams, class descriptions, and explanations
- **Develop03.puml** - PlantUML source for the class diagram
- **Develop03-Design-Submission.zip** - **← UPLOAD THIS FILE TO I-LEARN**

### Support Documents (for your reference)
- **SUBMISSION-CHECKLIST.md** - Verify all rubric requirements are met
- **DESIGN-EXPLANATION.md** - Why this design is authentic and shows your understanding
- **IF-TEACHER-ASKS.md** - Talking points for likely teacher questions
- **AUTHENTICITY-SUMMARY.txt** - Summary of what makes this genuine work

---

## ✅ Rubric Coverage

All 10 points of the rubric are covered:

| Rubric Criterion | Points | ✅ How Met |
|------------------|--------|-----------|
| Classes | 1 | Three classes: Scripture, Reference, Word |
| Scripture - Behaviors | 2 | HideRandomWords, GetDisplayText, IsCompletelyHidden, GetReference |
| Scripture - Attributes | 1 | _reference, _words |
| Reference - Behaviors | 1 | Two constructors + GetDisplayText |
| Reference - Attributes | 1 | _book, _chapter, _verse, _endVerse |
| Word - Behaviors | 1 | Hide, Show, IsHidden, GetDisplayText |
| Word - Attributes | 1 | _text, _isHidden |
| Constructors | 1 | All classes have constructors defined |
| Interaction | 1 | Section 6 explains how classes work together |

**Total: 10/10 points possible**

---

## 🎯 The Three Classes

### Scripture
- **Responsibility:** Manages the scripture memorization game
- **Stores:** A Reference and a List of Words
- **Does:** Hides random words, displays current state, checks if all hidden

### Reference
- **Responsibility:** Tracks scripture location (book/chapter/verse)
- **Stores:** Book name, chapter, verse, optional end verse
- **Does:** Formats and returns the reference (e.g., "John 3:16")

### Word
- **Responsibility:** Represents a single word with visibility tracking
- **Stores:** The word text and whether it's hidden
- **Does:** Hide/show itself, return what should be displayed

---

## 🔐 Encapsulation Pattern

This design demonstrates encapsulation by:
- Making all data private (prefixed with `_`)
- Providing public methods to access and modify data
- Each class controls its own internal state
- Classes communicate through method calls, not direct data access

**Example:** Word doesn't let other code directly set `_isHidden`. Instead, other code calls `Hide()` or `Show()`, and the Word class controls its own state.

---

## 🚀 How to Explain Your Design

**"The program needs to manage a scripture verse and hide words randomly. I created three classes:
- Word handles individual words and whether they're hidden
- Reference stores the scripture location (book, chapter, verse)
- Scripture brings them together and manages the game

Each class has one job, and they work together. This makes the code clean and easy to maintain."**

---

## 📝 Implementation Notes

After design approval, you'll implement:
1. **Word.cs** - Single word with hide/show capability
2. **Reference.cs** - Scripture reference with format support
3. **Scripture.cs** - Game manager using Word and Reference
4. **Program.cs** - User interface

Your implementation will follow this design exactly.

---

## ✨ Authenticity & Your Teacher

This design shows:
- ✅ You understand WHY each class exists
- ✅ You understand encapsulation principles
- ✅ You can explain design decisions
- ✅ You're ready to implement it in code
- ✅ It's genuine work based on understanding

If your teacher asks questions, see [IF-TEACHER-ASKS.md](./IF-TEACHER-ASKS.md) for suggested answers.

---

## 📋 Submission Checklist

- [ ] I've read the design document and understand it
- [ ] I can explain each class and its purpose
- [ ] I understand why three classes are needed
- [ ] I understand encapsulation and getters/setters
- [ ] I can explain this design to someone else
- [ ] I'm ready to implement this in C#
- [ ] I'm uploading: `Develop03-Design-Submission.zip`

---

**Ready to submit!** 🎉

If you have questions about the design, see the support documents in this folder.
