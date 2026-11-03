# Mindfulness Program - Design Submission
## CSE 210: Programming with Classes - Inheritance Activity

---

## 1. Program Overview

The Mindfulness Program provides three different guided mindfulness activities to help users reduce stress and build resilience:
- **Breathing Activity**: Guides users through paced deep breathing exercises
- **Reflection Activity**: Prompts users to reflect on moments of personal strength
- **Listing Activity**: Guides users to enumerate positive attributes and achievements

All activities follow a consistent structure:
1. Display starting message (activity name, description, request duration)
2. Execute the specific activity 
3. Display ending message with completion summary

---

## 2. Class Hierarchy Diagram

```
┌──────────────────────────────────────────────────┐
│                 Activity (Base)                  │
├──────────────────────────────────────────────────┤
│ Attributes:                                      │
│  - _name: string                                 │
│  - _description: string                          │
│  - _duration: int (seconds)                      │
├──────────────────────────────────────────────────┤
│ Methods:                                         │
│  # Activity()                                    │
│  # DisplayStartingMessage(): void                │
│  # DisplayEndingMessage(): void                  │
│  # Pause(): void                                 │
│  # PauseWithCountdown(seconds): void             │
│  + Run(): void (virtual)                         │
│  + GetName(): string                             │
│  + GetDescription(): string                      │
│  + GetDuration(): int                            │
│  + SetDuration(seconds): void                    │
└──────────────────────────────────────────────────┘
         │ inherited by
         ├─────────────────┬─────────────────┐
         ▼                 ▼                 ▼
┌────────────────────┐ ┌──────────────────┐ ┌──────────────────┐
│ BreathingActivity  │ │ReflectingActivity│ │ ListingActivity  │
├────────────────────┤ ├──────────────────┤ ├──────────────────┤
│ Attributes: (none) │ │ Attributes:      │ │ Attributes:      │
│                    │ │ - _prompts:      │ │ - _prompts:      │
│ Methods:           │ │   List<string>   │ │   List<string>   │
│ + Run(): void      │ │ - _questions:    │ │ - _strengths:    │
│                    │ │   List<string>   │ │   List<string>   │
│ (private helper    │ │                  │ │                  │
│  methods may be    │ │ Methods:         │ │ Methods:         │
│  added as needed)  │ │ + Run(): void    │ │ + Run(): void    │
│                    │ │ - GetRandom...() │ │ - GetRandom...() │
│                    │ │ - Display...():  │ │ - Display...():  │
│                    │ │   void           │ │   void           │
└────────────────────┘ └──────────────────┘ └──────────────────┘
```

---

## 3. Detailed Class Specifications

### Base Class: Activity

**Purpose:** Provides common functionality shared by all mindfulness activities, including starting/ending messages, pause mechanics, and duration management.

#### Attributes:
| Attribute | Type | Access | Description |
|-----------|------|--------|-------------|
| `_name` | `string` | protected | The name of the activity (e.g., "Breathing") |
| `_description` | `string` | protected | A description of the activity and its benefits |
| `_duration` | `int` | protected | The duration of the activity in seconds |

#### Methods:

| Method | Access | Parameters | Return Type | Description |
|--------|--------|-----------|------------|-------------|
| `Activity()` | protected | None | Constructor | Base constructor; may set default values or remain for derived classes to initialize |
| `DisplayStartingMessage()` | protected | None | void | Displays the activity name and description, prompts user for duration, stores duration, displays "Get ready..." message |
| `DisplayEndingMessage()` | protected | None | void | Displays completion message with activity name and duration, followed by a closing animation |
| `Pause()` | protected | None | void | Shows a simple animation (e.g., spinner) while pausing briefly |
| `PauseWithCountdown(int seconds)` | protected | int seconds | void | Shows a countdown timer, decrementing from the given seconds to 0 |
| `Run()` | public | None | void | Virtual method; executes the specific activity. Overridden by derived classes |
| `GetName()` | public | None | string | Returns the activity name |
| `GetDescription()` | public | None | string | Returns the activity description |
| `GetDuration()` | public | None | int | Returns the activity duration in seconds |
| `SetDuration(int seconds)` | public | int seconds | void | Sets the activity duration |

#### Constructor Details:
```csharp
// Base class may not need parameters; derived classes handle initialization
protected Activity()
{
    _name = "";
    _description = "";
    _duration = 0;
}
```

---

### Derived Class: BreathingActivity

**Purpose:** Guides the user through a paced deep breathing exercise with alternating "Breathe in..." and "Breathe out..." messages.

#### Attributes:
| Attribute | Type | Access | Description |
|-----------|------|--------|-------------|
| (none) | | | Uses only inherited attributes from Activity |

#### Unique Behaviors/Methods:

| Method | Access | Parameters | Return Type | Description |
|--------|--------|-----------|------------|-------------|
| `BreathingActivity()` | public | None | Constructor | Initializes the activity with name "Breathing", description, and default duration |
| `Run()` | public | None | void | Overrides base Run(); displays starting message, executes breathing sequence, displays ending message |

#### Constructor Details:
```csharp
public BreathingActivity()
{
    _name = "Breathing";
    _description = "This activity will help you relax by walking you through " +
                   "breathing in and out slowly. Clear your mind and focus on " +
                   "your breathing.";
    _duration = 0;  // Will be set by DisplayStartingMessage
}
```

#### Run() Method Flow:
1. Call `DisplayStartingMessage()`
2. Loop until duration elapsed:
   - Display "Breathe in..."
   - Pause with countdown (4 seconds)
   - Display "Breathe out..."
   - Pause with countdown (4 seconds)
   - Track total elapsed time
3. Call `DisplayEndingMessage()`

---

### Derived Class: ReflectingActivity

**Purpose:** Guides the user to reflect deeply on a time when they demonstrated strength or resilience, using a random prompt and follow-up questions.

#### Attributes:
| Attribute | Type | Access | Description |
|-----------|------|--------|-------------|
| `_prompts` | `List<string>` | private | Collection of reflection prompts to choose from randomly |
| `_questions` | `List<string>` | private | Collection of follow-up questions to deepen reflection |

#### Unique Behaviors/Methods:

| Method | Access | Parameters | Return Type | Description |
|--------|--------|-----------|------------|-------------|
| `ReflectingActivity()` | public | None | Constructor | Initializes the activity with name, description, prompts, and questions |
| `Run()` | public | None | void | Overrides base Run(); displays starting message, shows prompt, asks questions, displays ending message |
| `GetRandomPrompt()` | private | None | string | Returns a random prompt from the _prompts list |
| `GetRandomQuestion()` | private | None | string | Returns a random question from the _questions list |
| `DisplayPrompt(string prompt)` | private | string prompt | void | Displays a prompt and waits for user to press Enter |
| `DisplayQuestions()` | private | None | void | Displays random questions with pauses, collecting (but not storing) user responses |

#### Constructor Details:
```csharp
public ReflectingActivity()
{
    _name = "Reflecting";
    _description = "This activity will help you reflect on times in your life " +
                   "when you have shown strength and resilience. This will help " +
                   "you recognize the power you have and how you can use it in " +
                   "other aspects of your life.";
    _duration = 0;
    
    _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        // Additional prompts as needed
    };
    
    _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        // Additional questions as needed
    };
}
```

#### Run() Method Flow:
1. Call `DisplayStartingMessage()`
2. Get and display a random prompt
3. Pause briefly (allowing user to think)
4. Loop for the specified duration:
   - Get and display random question
   - Pause with countdown (sufficient time for user to respond)
5. Call `DisplayEndingMessage()`

---

### Derived Class: ListingActivity

**Purpose:** Guides the user to list as many positive attributes or accomplishments as possible within the specified time duration.

#### Attributes:
| Attribute | Type | Access | Description |
|-----------|------|--------|-------------|
| `_prompts` | `List<string>` | private | Collection of prompts to guide user listing |

#### Unique Behaviors/Methods:

| Method | Access | Parameters | Return Type | Description |
|--------|--------|-----------|------------|-------------|
| `ListingActivity()` | public | None | Constructor | Initializes the activity with name, description, and prompts |
| `Run()` | public | None | void | Overrides base Run(); displays starting message, shows prompt, collects list items, displays ending message |
| `GetRandomPrompt()` | private | None | string | Returns a random prompt from the _prompts list |
| `GetListFromUser(int durationSeconds)` | private | int durationSeconds | int | Displays a prompt and collects items from the user until time expires; returns count of items |

#### Constructor Details:
```csharp
public ListingActivity()
{
    _name = "Listing";
    _description = "This activity will help you reflect on the good things in " +
                   "your life by having you list as many things as you can in a " +
                   "certain area.";
    _duration = 0;
    
    _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this year?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        // Additional prompts as needed
    };
}
```

#### Run() Method Flow:
1. Call `DisplayStartingMessage()`
2. Get and display a random prompt
3. Display countdown/notification that they're about to start listing
4. Pause briefly
5. Call `GetListFromUser(_duration)` to collect user items and count them
6. Display the count of items listed
7. Call `DisplayEndingMessage()`

---

## 4. Program Flow Diagram

```
Start Program
    │
    ▼
Display Menu
    │
    ├─ Option 1: Breathing Activity
    │   ├─ Create BreathingActivity instance
    │   ├─ Call Run()
    │   │  ├─ DisplayStartingMessage()
    │   │  ├─ Loop: "Breathe in" / PauseWithCountdown / "Breathe out" / PauseWithCountdown
    │   │  └─ DisplayEndingMessage()
    │   └─ Return to menu
    │
    ├─ Option 2: Reflecting Activity
    │   ├─ Create ReflectingActivity instance
    │   ├─ Call Run()
    │   │  ├─ DisplayStartingMessage()
    │   │  ├─ GetRandomPrompt() → DisplayPrompt()
    │   │  ├─ Pause()
    │   │  ├─ Loop: GetRandomQuestion() → Display → Pause()
    │   │  └─ DisplayEndingMessage()
    │   └─ Return to menu
    │
    ├─ Option 3: Listing Activity
    │   ├─ Create ListingActivity instance
    │   ├─ Call Run()
    │   │  ├─ DisplayStartingMessage()
    │   │  ├─ GetRandomPrompt() → DisplayPrompt()
    │   │  ├─ GetListFromUser() → Collect items with timer
    │   │  ├─ Display item count
    │   │  └─ DisplayEndingMessage()
    │   └─ Return to menu
    │
    └─ Option 4: Quit
        └─ End Program
```

---

## 5. Key Design Decisions

### Inheritance Strategy
- **Base Activity Class**: All three activities share common behavior patterns (starting message, ending message, pause mechanics, duration management). Using inheritance eliminates code duplication and ensures consistency.
- **Virtual Run() Method**: Each derived class implements its own version of the core activity logic while leveraging inherited support methods.

### Protected vs. Private vs. Public Access
- **Protected** attributes/methods in base class allow derived classes to access common data and behaviors
- **Private** helpers in derived classes (e.g., `GetRandomPrompt()`) are not needed outside the activity
- **Public** main entry point (`Run()`) and getter methods allow external code (Program class/menu) to interact with activities

### Data Storage
- **Prompts and Questions**: Stored as `List<string>` for flexibility; can be easily expanded or modified
- **No Persistent State**: Activities don't store user input; focus is on guiding the user through the exercise

### Timing Implementation
- `PauseWithCountdown()` uses a simple loop with delays
- `Pause()` provides a spinner animation for smoother UX
- Durations are measured in seconds for simplicity

---

## 6. Implementation Sequence (Recommended)

1. **Create Activity Base Class**
   - Define attributes and core methods
   - Implement display and pause logic

2. **Create BreathingActivity**
   - Simplest derived class; good starting point
   - Implement Run() with breathing sequence

3. **Create ReflectingActivity**
   - Add prompts and questions lists
   - Implement random selection and display

4. **Create ListingActivity**
   - Add prompts list
   - Implement user input collection with timer

5. **Create Program/Menu**
   - Create instances of each activity
   - Implement menu loop
   - Call appropriate Run() method

---

## 7. Example Usage

```csharp
// In Program.cs or Main method
Activity current = null;

while (true)
{
    Console.WriteLine("\nMenu Options:");
    Console.WriteLine("1. Start breathing activity");
    Console.WriteLine("2. Start reflecting activity");
    Console.WriteLine("3. Start listing activity");
    Console.WriteLine("4. Quit");
    Console.Write("Select a choice (1-4): ");
    
    string choice = Console.ReadLine();
    
    switch (choice)
    {
        case "1":
            current = new BreathingActivity();
            current.Run();
            break;
        case "2":
            current = new ReflectingActivity();
            current.Run();
            break;
        case "3":
            current = new ListingActivity();
            current.Run();
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
```

---

## 8. Notes

- This design follows object-oriented principles with clear separation of concerns
- The inheritance hierarchy allows for easy addition of new activity types in the future
- All timing and animation is handled by the base class, making it simple and consistent
- The design focuses on code reusability and maintainability
