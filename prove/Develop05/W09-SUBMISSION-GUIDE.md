# W09 Designer - Submission Guide

## 📋 Assignment: W09 Designer (Polymorphism Design Activity)

---

## 🎯 What to Submit

**File**: `W09-DESIGN-SUBMISSION.md`

This comprehensive design document includes:
- ✅ **PlantUML Class Diagram** (rendered as image)
- ✅ **All 8 Rubric Requirements**:
  1. Classes & Inheritance hierarchy
  2. Method Overriding details
  3. Base Goal Class behaviors
  4. Base Goal Class attributes
  5. Derived classes behaviors
  6. Derived classes attributes
  7. Constructors for all classes
  8. Interaction diagram and program flow

---

## 📤 How to Submit to I-Learn

1. **Go to**: I-Learn → CSE 210 → **W09 Designer**

2. **Click**: "Submit Assignment"

3. **Upload File**: `W09-DESIGN-SUBMISSION.md`
   - This file contains everything needed
   - Includes the diagram and all explanations

4. **Click**: Submit

---

## ✅ What's Included in the Document

### Section 1: Class Diagram (with rendered image)
- Shows all 6 classes (Goal, SimpleGoal, EternalGoal, ChecklistGoal, GoalManager, Program)
- Shows all attributes with types
- Shows all methods with parameters and return types
- Shows inheritance relationships
- Shows composition relationships

### Section 2-8: Detailed Rubric Coverage
Each section addresses one rubric criterion with:
- ✅ What it covers
- ✅ Why it's designed this way
- ✅ Implementation details
- ✅ Code examples where applicable

### Section 8: Interaction Diagram
Complete program flow showing:
- How the program starts
- How goals are created
- How events are recorded
- How polymorphism works
- How persistence works (save/load)

---

## 📐 Rubric Verification

The submitted document covers all rubric items:

| Rubric Item | Points | Covered In |
|-------------|--------|-----------|
| Classes & Inheritance | 2 pts | Sections 1 & 2 |
| Method Overriding | 1 pt | Section 2 |
| Base Class Behaviors | 2 pts | Section 3 |
| Base Class Attributes | 1 pt | Section 4 |
| Derived Class Behaviors | 1 pt | Section 5 |
| Derived Class Attributes | 1 pt | Section 6 |
| Constructors | 1 pt | Section 7 |
| Interaction | 1 pt | Section 8 |

**Total: 10/10 points possible**

---

## 🎨 Class Diagram Details

The PlantUML-style class diagram shows:

**Goal (Abstract Base Class)**
- Protected attributes: _name, _description, _points
- Public methods: Constructors, getters, abstract methods
- Virtual methods for persistence

**Three Derived Classes**
- SimpleGoal: One-time completion
- EternalGoal: Never completes, repeats forever
- ChecklistGoal: Multiple completions with bonus

**GoalManager (Manager Class)**
- Manages collection of goals
- Handles persistence (save/load)
- Tracks score

**Program (UI Class)**
- Menu system
- User interaction
- Calls GoalManager

---

## 🔗 File Location

The design document is located at:
```
/prove/Develop05/W09-DESIGN-SUBMISSION.md
```

And is accessible at:
```
https://github.com/Crabtree-im/BYUI-Programming-with-classes/blob/main/prove/Develop05/W09-DESIGN-SUBMISSION.md
```

---

## ✨ Why This Will Get Full Points

✅ **Comprehensive**: Addresses all 8 rubric criteria  
✅ **Clear**: Each section is well-organized and explained  
✅ **Visual**: Includes PlantUML class diagram with rendered image  
✅ **Detailed**: Shows all classes, attributes, methods, relationships  
✅ **Interaction**: Includes detailed program flow explanation  
✅ **Professional**: Follows UML conventions and proper formatting  

---

## 📝 Notes

- The design document was created based on the actual implementation
- PlantUML diagram uses proper UML notation
- All 6 classes are included as required
- All methods and attributes are shown with types
- Constructors are defined for all classes
- Interaction is explained with detailed flow diagrams

---

**Status**: ✅ Ready to submit  
**Expected Score**: 10/10
