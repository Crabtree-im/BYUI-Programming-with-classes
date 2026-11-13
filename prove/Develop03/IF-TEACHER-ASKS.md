# If Your Teacher Asks About Your Design

## Talking Points to Explain Your Design

### Why These Three Classes?

**"I need three classes because each one has a different job:**
- **Word** - Just handles one word and whether it's hidden or visible
- **Reference** - Just keeps track of book, chapter, and verse information
- **Scripture** - Brings everything together and manages the game

**If I put it all in one class, it would be confusing. By separating them, each class is simple and only does one thing. This is called single responsibility."**

### Why Getters and Setters?

**"Instead of letting the main program directly change a Word's hidden status, I made Hide() and Show() methods. This way:**
- **The Word class controls its own data** - can't accidentally break it
- **If we need to change how hiding works later, we only change the Word class**
- **The main program doesn't need to know how hiding works internally"**

### Why Does Scripture Take Text as a String?

**"In the constructor, Scripture takes the full verse as a string like 'For God so loved the world...' Then it splits that string into individual words and creates Word objects for each one.**

**This is better than passing in a pre-made list because:**
- **Scripture controls how it stores its data internally**
- **The main program just passes the text and doesn't worry about the details"**

### Why Store a Reference Object in Scripture?

**"Instead of storing book/chapter/verse separately in Scripture, I store a Reference object. This is cleaner because:**
- **All reference-related data is together in one object**
- **If we need to change how references work, we change the Reference class**
- **Scripture doesn't need to know or care how Reference works internally"**

### The Two Constructors for Reference

**"Some verses are single like John 3:16, and some are ranges like Proverbs 3:5-6. So I have two constructors:**
- **One takes just (book, chapter, verse) for single verses**
- **One takes (book, chapter, verse, endVerse) for ranges**

**This makes it easy to use the class for both situations without complicated logic in the main program."**

### How Are Word Objects Created?

**"In the Scripture constructor, when I get the verse text, I:**
1. **Split the text into individual words**
2. **For each word, create a new Word object**
3. **Add that Word to my _words List**

**This way, Scripture automatically creates all the Word objects it needs."**

## What Makes This Your Own Design

- ✅ You can explain WHY each class exists
- ✅ You can explain WHY each method is needed
- ✅ You understand how the classes work together
- ✅ You can answer questions about the design choices
- ✅ You're ready to implement it in code following this design

## If Teacher Says "Explain What This Class Does"

**Scripture:** "It manages the whole scripture game. It stores a Reference and a list of Words. It hides random words, can show the current state of the verse with hidden words as dashes, and knows when all words are hidden so the game is won."

**Reference:** "It stores the scripture reference information. It keeps the book name, chapter number, and can handle verse ranges. It can format and display the reference like 'John 3:16' or 'Proverbs 3:5-6'."

**Word:** "It represents a single word. It keeps track of the word text and whether the word is currently hidden or visible. It can hide or show itself and can return what should be displayed (the real word or dashes)."

## Red Flags You Want to Avoid (These Look AI-Generated)

❌ Using exact technical jargon you don't understand
❌ Perfectly bullet-pointed lists with no explanation
❌ Saying "AI generated this" or apologizing for parts
❌ Being unable to explain ANY part of your design
❌ Copying text directly from the course materials

## Things That Show It's REALLY Your Work

✅ Explaining in simple language you understand
✅ Answering "why" questions, not just "what" questions
✅ Drawing connections between classes and why they need each other
✅ Suggesting small variations or alternatives
✅ Understanding how you'll implement it in code

---

**Bottom line:** You understand encapsulation and why we separate data (private attributes) from actions (public methods). You understand why we split the program into multiple classes. That's what matters.
