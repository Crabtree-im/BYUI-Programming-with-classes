# Develop05: Eternal Quest Program

## Overview
This is a goal-tracking program demonstrating the principle of **polymorphism** in C#. Users can create different types of goals, track progress, earn points, and save their data.

## Polymorphism Demonstrated

### Three Goal Types
All derive from an abstract `Goal` base class and override three key methods:

1. **SimpleGoal** - Complete once, earn points
   - Example: Run a marathon (1000 points)
   - `RecordEvent()`: Returns points once, then 0
   - `IsComplete()`: Returns true after first completion
   - `GetDisplayString()`: Shows "[X]" when complete, "[ ]" when not

2. **EternalGoal** - Repeat infinitely, earn points each time
   - Example: Read scriptures daily (100 points)
   - `RecordEvent()`: Always returns points
   - `IsComplete()`: Always returns false
   - `GetDisplayString()`: Always shows "[ ]" (never complete)

3. **ChecklistGoal** - Complete N times, earn points + bonus on completion
   - Example: Attend temple 10 times (50 points each, 500 bonus at 10th)
   - `RecordEvent()`: Returns points + bonus when target reached
   - `IsComplete()`: Returns true when `_amountCompleted >= _targetAmount`
   - `GetDisplayString()`: Shows "[X] name - Completed X/Y times"

## The Power of Polymorphism

The same code works for all goal types without type-checking:

```csharp
int pointsEarned = goal.RecordEvent();  // One line of code
_score += pointsEarned;                 // Different behavior based on goal type!
```

No need for:
```csharp
if (goal is SimpleGoal) { ... }
else if (goal is ChecklistGoal) { ... }
```

Each goal knows how to respond. This is polymorphism.

## File Structure

| File | Purpose |
|------|---------|
| `Goal.cs` | Abstract base class defining the interface |
| `SimpleGoal.cs` | Single-completion goal implementation |
| `EternalGoal.cs` | Infinite-repetition goal implementation |
| `ChecklistGoal.cs` | Multi-completion goal implementation |
| `GoalManager.cs` | Manages goal collection, score, persistence |
| `Program.cs` | Menu-driven user interface |

## Features

✅ Create goals of three types with user input
✅ Record goal completion events
✅ Track score across sessions
✅ Display goals with status (checkbox, progress count)
✅ Save/load goals to file (goals.txt)
✅ Menu-driven interface with input validation

## Design Standards Met

- **Inheritance**: `Goal` base class with derived classes
- **Polymorphism**: Method overriding with `abstract` and `override` keywords
- **Encapsulation**: Private fields, public methods
- **Naming Conventions**: `_camelCase` for fields, `PascalCase` for types/methods
- **Abstraction**: `Goal` is abstract; implementation details hidden in derived classes
- **Liskov Substitution**: Any goal type works anywhere a `Goal` is expected

## Data Persistence

Goals and scores are saved to `goals.txt` in format:
```
Score:1500
SimpleGoal:Marathon:Run a marathon:1000:true
EternalGoal:Scripture:Read daily:100
ChecklistGoal:Temple:Visit temple:50:10:500:7
```

## Design Documentation

See [DESIGN-SUBMISSION.md](./DESIGN-SUBMISSION.md) for:
- Complete class diagram
- Detailed behavior specifications
- Program flow diagrams
- Interaction descriptions

See [IMPLEMENTATION-VERIFICATION.md](./IMPLEMENTATION-VERIFICATION.md) for:
- Full compliance checklist against design standards
- Code examples for each principle
- Verification of polymorphic behavior

## Building and Running

```bash
cd prove/Develop05
dotnet build
dotnet run
```

## Design Source

UML class diagram source: `Develop05-Design.puml` (PlantUML format)

---

**This program demonstrates all four principles of programming with classes:**
1. Abstraction (abstract Goal class)
2. Encapsulation (private fields, public methods)
3. Inheritance (SimpleGoal, EternalGoal, ChecklistGoal extend Goal)
4. Polymorphism (method overriding with different behaviors)
