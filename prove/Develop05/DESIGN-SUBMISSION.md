# Eternal Quest - Design Submission
## CSE 210: Programming with Classes - Polymorphism Activity

---

## 1. Class Diagram Overview

```
                          ┌─────────────────────────────────────────┐
                          │      <<abstract>> Goal                  │
                          ├─────────────────────────────────────────┤
                          │ Attributes:                             │
                          │  # _name: string                        │
                          │  # _description: string                 │
                          │  # _points: int                         │
                          ├─────────────────────────────────────────┤
                          │ Methods:                                │
                          │  + Goal(name, description, points)      │
                          │  + GetName(): string                    │
                          │  + GetDescription(): string             │
                          │  + GetPoints(): int                     │
                          │  + {abstract} RecordEvent(): int        │
                          │  + {abstract} IsComplete(): bool        │
                          │  + {abstract} GetDisplayString(): str   │
                          │  + GetStringRepresentation(): string    │
                          │  + SetFromStringRepresentation(data)    │
                          └─────────────────────────────────────────┘
                                    △
                    ┌───────────────┼───────────────┐
                    │               │               │
                    │               │               │
        ┌───────────▼──────┐  ┌─────▼─────────┐  ┌─▼────────────────┐
        │  SimpleGoal      │  │ EternalGoal   │  │ ChecklistGoal    │
        ├──────────────────┤  ├───────────────┤  ├──────────────────┤
        │ Attributes:      │  │ Attributes:   │  │ Attributes:      │
        │  - _isComplete   │  │  (inherited)   │  │  - _amountCompl. │
        │    : bool        │  │               │  │    : int         │
        │                  │  │               │  │  - _targetAmount │
        ├──────────────────┤  ├───────────────┤  │    : int         │
        │ Methods:         │  │ Methods:      │  │  - _bonusPoints  │
        │  + SimpleGoal()  │  │  + EternalG() │  │    : int         │
        │  + RecordEvent() │  │  + RecordEv() │  ├──────────────────┤
        │  + IsComplete()  │  │  + IsCompl()  │  │ Methods:         │
        │  + GetDisplay()  │  │  + GetDisp()  │  │  + ChecklistG()  │
        └──────────────────┘  └───────────────┘  │  + RecordEvent() │
                                                  │  + IsComplete()  │
                                                  │  + GetDisplay()  │
                                                  │  + GetAmountDone │
                                                  │  + GetTargetAmt  │
                                                  └──────────────────┘

                          ┌──────────────────────────┐
                          │   GoalManager            │
                          ├──────────────────────────┤
                          │ Attributes:              │
                          │  - _goals: List<Goal>    │
                          │  - _score: int           │
                          │  - _fileName: string     │
                          ├──────────────────────────┤
                          │ Methods:                 │
                          │  + GoalManager()         │
                          │  + AddGoal(goal)         │
                          │  + RecordGoalEvent(idx)  │
                          │  + GetGoals()            │
                          │  + GetScore(): int       │
                          │  + AddToScore(points)    │
                          │  + SaveGoals()           │
                          │  + LoadGoals()           │
                          └──────────────────────────┘
                                    △
                                    │ uses
                                    │
                          ┌──────────▼──────────┐
                          │   Program           │
                          ├─────────────────────┤
                          │ Attributes:         │
                          │  - _goalManager     │
                          │    : GoalManager    │
                          ├─────────────────────┤
                          │ Methods:            │
                          │  + Main(args)       │
                          │  - DisplayMenu()    │
                          │  - CreateNewGoal()  │
                          │  - RecordEvent()    │
                          │  - ListGoals()      │
                          │  - SaveAndQuit()    │
                          └─────────────────────┘
```

---

## 2. Program Overview and Flow

### How the Program Runs

1. **Initialization**: Program starts and creates a `GoalManager`
2. **Load Goals**: Attempts to load previously saved goals from file
3. **Main Menu Loop**: Continuously displays menu until user quits
4. **User Actions**:
   - Create new goal (user selects type: Simple, Eternal, or Checklist)
   - Record event for a goal (goal completed, earn points)
   - View all goals (shows status and progress)
   - View score (displays total points)
   - Save and quit (saves all data to file)

### Data Flow Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                     PROGRAM START                           │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼
                    ┌──────────────┐
                    │ GoalManager  │
                    │  (created)   │
                    └──────┬───────┘
                           │
                           ▼
                  ┌────────────────────┐
                  │  LoadGoals()       │
                  │  (from file)       │
                  └────────┬───────────┘
                           │
                ┌──────────┴──────────┐
                │                     │
                ▼                     ▼
    ┌────────────────────┐  ┌────────────────┐
    │  Goals loaded OK   │  │  No prev file  │
    └────────┬───────────┘  └────────┬───────┘
             │                       │
             └───────────┬───────────┘
                         │
        ┌────────────────▼──────────────────┐
        │   Display Menu (Show Score)       │
        │   1. Create new goal              │
        │   2. Record goal event            │
        │   3. List all goals               │
        │   4. View score                   │
        │   5. Save and quit                │
        └────────────────┬──────────────────┘
                         │
            ┌────────────┼────────────┐
            │            │            │
            ▼            ▼            ▼
       ┌────────┐  ┌─────────┐  ┌─────────────┐
       │ Create │  │ Record  │  │List Goals & │
       │  Goal  │  │ Event   │  │Score/Save   │
       └────┬───┘  └────┬────┘  └────┬────────┘
            │           │            │
            ▼           ▼            ▼
        ┌────────────────────────────────────────┐
        │   Loop back to Menu                    │
        └────────────────────────────────────────┘
                         │
                         ▼
           ┌─────────────────────────┐
           │  User selects Save/Quit │
           └─────────────┬───────────┘
                         │
                         ▼
              ┌────────────────────┐
              │  SaveGoals()       │
              │  (to file)         │
              └────────┬───────────┘
                       │
                       ▼
              ┌────────────────────┐
              │   PROGRAM ENDS     │
              └────────────────────┘
```

---

## 3. Class Details

### Base Class: Goal (Abstract)

**Purpose**: Define the common interface and shared functionality for all goal types. This is where polymorphism is achieved.

#### Attributes:
| Attribute | Type | Visibility | Description |
|-----------|------|-----------|-------------|
| `_name` | `string` | Protected | Name of the goal |
| `_description` | `string` | Protected | Description of what the goal is |
| `_points` | `int` | Protected | Points awarded for this goal |

#### Key Methods:
| Method | Parameters | Return | Description |
|--------|-----------|--------|-------------|
| `RecordEvent()` | None | `int` | **POLYMORPHIC**: Called when user completes the goal. Returns points earned (may include bonus). Implementation varies by goal type. |
| `IsComplete()` | None | `bool` | **POLYMORPHIC**: Determines if goal is complete. Returns `true`/`false` based on goal type logic. |
| `GetDisplayString()` | None | `string` | **POLYMORPHIC**: Returns formatted string showing goal status for list display. Format varies by type. |
| `GetStringRepresentation()` | None | `string` | Returns a comma-separated string of all attributes for saving to file |
| `SetFromStringRepresentation()` | `string data` | `void` | Parses a comma-separated string to restore object state from file |

#### Why Abstract?
- Forces derived classes to implement `RecordEvent()`, `IsComplete()`, and `GetDisplayString()`
- Guarantees all goal types have consistent interface
- Cannot instantiate `Goal` directly; must use derived types

---

### Derived Class: SimpleGoal

**Purpose**: Represents a goal that can be marked complete (like running a marathon).

#### Additional Attributes:
| Attribute | Type | Visibility | Description |
|-----------|------|-----------|-------------|
| `_isComplete` | `bool` | Private | Tracks whether goal has been completed |

#### Constructor:
```csharp
SimpleGoal(string name, string description, int points)
  - Calls base constructor with name, description, points
  - Initializes _isComplete to false
```

#### Overridden Methods:

**RecordEvent()**
- If goal not yet complete:
  - Sets `_isComplete = true`
  - Returns the `_points` value
- If already complete:
  - Returns 0 (no additional points)

**IsComplete()**
- Returns value of `_isComplete`

**GetDisplayString()**
- Returns formatted string like: `[X] Run a Marathon - Run 1 marathon` (if complete)
- Or: `[ ] Run a Marathon - Run 1 marathon` (if not complete)

---

### Derived Class: EternalGoal

**Purpose**: Represents a goal that never completes but earns points each time (like reading scriptures daily).

#### Additional Attributes:
- None (inherits all from base `Goal`)

#### Constructor:
```csharp
EternalGoal(string name, string description, int points)
  - Calls base constructor with name, description, points
```

#### Overridden Methods:

**RecordEvent()**
- Always returns `_points` value (no limit)
- No completion tracking needed

**IsComplete()**
- Always returns `false` (never complete)

**GetDisplayString()**
- Returns formatted string like: `[ ] Read Scriptures - Scripture reading` (shows incomplete status)

---

### Derived Class: ChecklistGoal

**Purpose**: Represents a goal with a target number of completions (like attending temple 10 times).

#### Additional Attributes:
| Attribute | Type | Visibility | Description |
|-----------|------|-----------|-------------|
| `_amountCompleted` | `int` | Private | How many times goal has been completed so far |
| `_targetAmount` | `int` | Private | How many times goal needs to be completed |
| `_bonusPoints` | `int` | Private | Extra points earned when target is reached |

#### Constructor:
```csharp
ChecklistGoal(string name, string description, int points, 
              int targetAmount, int bonusPoints)
  - Calls base constructor with name, description, points
  - Sets _targetAmount = targetAmount
  - Sets _bonusPoints = bonusPoints
  - Initializes _amountCompleted = 0
```

#### Overridden Methods:

**RecordEvent()**
- Increment `_amountCompleted` by 1
- Add `_points` to earned value
- If `_amountCompleted == _targetAmount`:
  - Add `_bonusPoints` to earned value
  - Return total (points + bonus)
- Otherwise:
  - Return just points (no bonus)

**IsComplete()**
- Returns `true` if `_amountCompleted >= _targetAmount`
- Returns `false` otherwise

**GetDisplayString()**
- Returns formatted string like:
  - `[X] Attend Temple - Completed 10/10 times` (if complete)
  - `[ ] Attend Temple - Completed 3/10 times` (if not complete)

---

### GoalManager Class

**Purpose**: Manages the collection of goals and handles user score tracking, saving, and loading.

#### Attributes:
| Attribute | Type | Visibility | Description |
|-----------|------|-----------|-------------|
| `_goals` | `List<Goal>` | Private | Collection of all goals |
| `_score` | `int` | Private | User's total accumulated points |
| `_fileName` | `string` | Private | Name of file for persistence |

#### Constructor:
```csharp
GoalManager()
  - Initializes empty _goals list
  - Sets _score = 0
  - Sets _fileName to something like "goals.txt"
```

#### Key Methods:

| Method | Purpose |
|--------|---------|
| `AddGoal(Goal goal)` | Adds new goal to the list |
| `RecordGoalEvent(int goalIndex)` | Records that a goal was completed, adds earned points to score |
| `GetGoals()` | Returns the list of all goals |
| `GetScore()` | Returns current score |
| `AddToScore(int points)` | Adds points to user's score |
| `SaveGoals()` | Saves all goals and score to a file using `GetStringRepresentation()` |
| `LoadGoals()` | Loads goals and score from file using `SetFromStringRepresentation()` |

#### Polymorphism in Action:
When `RecordGoalEvent(index)` is called:
- Doesn't need to know goal type
- Calls `_goals[index].RecordEvent()`
- Each goal's specific logic automatically runs
- Points are added to score

This is polymorphism: one method call, different behavior based on actual goal type.

---

### Program Class

**Purpose**: Handles user interaction through menu-driven interface.

#### Attributes:
| Attribute | Type | Visibility | Description |
|-----------|------|-----------|-------------|
| `_goalManager` | `GoalManager` | Private Static | Manages all goals throughout program execution |

#### Methods:

| Method | Purpose |
|--------|---------|
| `Main()` | Entry point; runs main menu loop; loads/saves goals |
| `DisplayMenu()` | Shows menu options; returns user's choice |
| `CreateNewGoal()` | Prompts user to create Simple, Eternal, or Checklist goal |
| `RecordGoalEvent()` | Shows list of goals; user selects which to record |
| `ListGoals()` | Displays all goals with their status |
| `SaveAndQuit()` | Saves all data and exits program |

---

## 4. Polymorphism in Action: Key Example

### The Critical Polymorphic Behavior

In `GoalManager.RecordGoalEvent()`:

```
User selects goal index
  │
  ▼
Call goal.RecordEvent()
  │
  ├─────────────────────────────────────────┐
  │                                         │
  ▼ (if SimpleGoal)                ▼ (if ChecklistGoal)
Returns _points (once)     Returns _points + bonus (on completion)
                           or _points (otherwise)
  │                                         │
  └─────────────────────────────────────────┘
  │
  ▼
Update score with returned points
```

**Key Point**: The `RecordEvent()` call doesn't change. The `GoalManager` doesn't have type-checking code like:
```csharp
if (goal is SimpleGoal) { ... }
else if (goal is ChecklistGoal) { ... }
```

Instead, each goal type knows how to respond to `RecordEvent()` based on its own logic. This is polymorphism.

---

## 5. Saving and Loading: Persistence Design

### File Format (goals.txt):
```
Score:1500
SimpleGoal:Run a Marathon:Run 1 marathon:1000:true
ChecklistGoal:Attend Temple:Temple attendance:50:10:500:7
EternalGoal:Read Scriptures:Daily scripture reading:100:false
```

Each line starts with the goal type, allowing the program to reconstruct the correct derived class when loading.

### Save Process:
1. For each goal in list:
   - Call `goal.GetStringRepresentation()`
   - Write to file

### Load Process:
1. For each line in file:
   - Parse the goal type
   - Create appropriate derived class
   - Call `SetFromStringRepresentation()` to restore state
   - Add to goals list

---

## 6. Design Principles Applied

### Inheritance
- **Goal** base class defines common attributes (`_name`, `_description`, `_points`)
- Derived classes (**SimpleGoal**, **EternalGoal**, **ChecklistGoal**) inherit from **Goal**

### Polymorphism
- **Method Overriding**: Each derived class overrides `RecordEvent()`, `IsComplete()`, and `GetDisplayString()`
- **Runtime Behavior**: Program calls methods on `Goal` references, actual method executed depends on runtime type
- **No Type Checking**: Code doesn't use `typeof()` or `is` checks; relies on polymorphic dispatch

### Encapsulation
- Member variables marked `private` or `protected`
- Getter methods for read-only access
- Business logic encapsulated in methods (not exposed to caller)

### Abstraction
- `Goal` is abstract; shows only essential interface
- Implementation details hidden in derived classes
- Users interact with goals through consistent interface

---

## 7. How Classes Interact

```
USER INPUT
    │
    ▼
Program.DisplayMenu()
    │
    ├─ User selects: Create Goal
    │   ▼
    │   Program.CreateNewGoal()
    │       │
    │       ├─ Gets type (Simple/Eternal/Checklist)
    │       ├─ Gets attributes
    │       ▼
    │       GoalManager.AddGoal(newGoal)
    │           ▼
    │           _goals.Add(newGoal)
    │
    ├─ User selects: Record Event
    │   ▼
    │   Program.RecordGoalEvent()
    │       ▼
    │       GoalManager.RecordGoalEvent(index)
    │           ▼
    │           goal.RecordEvent()  ◄─── POLYMORPHIC!
    │               │
    │               ├─ SimpleGoal: return points or 0
    │               ├─ EternalGoal: return points
    │               └─ ChecklistGoal: return points ± bonus
    │           ▼
    │           GoalManager.AddToScore(points)
    │               ▼
    │               _score += points
    │
    ├─ User selects: List Goals
    │   ▼
    │   Program.ListGoals()
    │       ▼
    │       For each goal:
    │           goal.GetDisplayString()  ◄─── POLYMORPHIC!
    │               │
    │               ├─ SimpleGoal: [X] or [ ]
    │               ├─ EternalGoal: [ ] (never complete)
    │               └─ ChecklistGoal: [X] or [ ] + X/Y times
    │
    └─ User selects: Save and Quit
        ▼
        GoalManager.SaveGoals()
            ▼
            For each goal:
                goal.GetStringRepresentation()
                    ▼
                    Write to file
```

---

## Summary

This design demonstrates polymorphism by:

1. **Defining a base `Goal` class** with abstract methods that must be overridden
2. **Creating derived classes** (SimpleGoal, EternalGoal, ChecklistGoal) with different implementations
3. **Using the same method names** (`RecordEvent()`, `IsComplete()`, `GetDisplayString()`)
4. **Storing objects in a base-type collection** (`List<Goal>`)
5. **Calling methods without type-checking** — the correct method runs automatically based on object type
6. **Allowing easy extension** — new goal types can be added without changing existing code

The result is a flexible, maintainable system where each goal type encapsulates its own logic while conforming to a common interface.
