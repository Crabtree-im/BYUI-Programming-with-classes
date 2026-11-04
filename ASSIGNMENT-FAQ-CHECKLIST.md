# CSE 210 Assignment FAQ Checklist

Use this checklist for assignments in this repository. It summarizes the
instructor FAQ supplied by the student and the instructor's feedback that a
design submission needs a class diagram.

## Before starting

- Read the assignment instructions and its grading rubric. Plan a response or
  deliverable for every rubric criterion.
- If the instructions and rubric conflict, ask the instructor for clarification
  in the class Help channel before proceeding.
- For a design assignment, also review the corresponding Developer: Prove
  requirements so the design supports the finished program.

## Design and class-diagram assignments

- Create the class diagram with **PlantUML** and follow UML class-diagram
  conventions.
- Include every class used by the program, including `Program` and its `Main`
  method.
- Show each class's attributes with types, method parameters with types, and
  return types for every method. Constructors have no return type.
- Use the course naming conventions consistently in the diagram and code:
  `_camelCase` fields, `camelCase` parameters and local variables,
  `PascalCase` class and method names, and `SCREAMING_SNAKE_CASE` constants.
- Include a written explanation or another diagram showing how classes and
  methods interact and how the program runs.
- Put the **rendered diagram image** in the submitted document. PlantUML source
  or a link by itself is not a substitute for the image. Keep the `.puml` source
  as a useful editable companion when appropriate.

## Written (Prove: Articulate) assignments

- Organize the document with headings that match the rubric criteria, except
  criteria such as length that are measured across the whole document.
- Address each requested point under its corresponding heading.
- When a prompt asks for a code example, include an actual excerpt from that
  week's Developer: Prove program. Describing code or naming classes and
  methods alone does not satisfy the example requirement.

## Programming (Prove: Developer) assignments

- Use C# and put the work in the specified location in the student template.
- Continue using the same GitHub account and repository used for the class.
- Use the provided `Program.cs` as the starting point.
- Put each class in its own `.cs` file named after the class.
- Follow the naming conventions above. Do not use properties, lambdas, or
  expression-bodied members for course assignments.
- Add a comment in `Program.cs` explaining how the program exceeds the
  requirements.

## Feedback and team activities

- Check rubric feedback and assignment comments, correct the identified issues,
  and resubmit when needed and allowed by the course schedule.
- For team activities, follow the meeting agenda and the course's attendance
  reporting requirements. Complete participation reports honestly.

## Source

Based on the instructor FAQ pasted by the student in this conversation and the
instructor's feedback on the Develop02 submission. PlantUML reference:
[Class Diagram syntax and features](https://plantuml.com/class-diagram).
