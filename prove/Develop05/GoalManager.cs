using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _fileName;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _fileName = "goals.txt";
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int RecordGoalEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            AddToScore(pointsEarned);
            return pointsEarned;
        }
        return 0;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int points)
    {
        _score += points;
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(_fileName))
        {
            writer.WriteLine($"Score:{_score}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists(_fileName))
        {
            return;
        }

        _goals.Clear();
        _score = 0;

        using (StreamReader reader = new StreamReader(_fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Score:"))
                {
                    _score = int.Parse(line.Substring("Score:".Length));
                }
                else
                {
                    Goal goal = CreateGoalFromString(line);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
        }
    }

    private Goal CreateGoalFromString(string data)
    {
        string[] parts = data.Split(":");
        string goalType = parts[0];

        switch (goalType)
        {
            case "SimpleGoal":
                {
                    SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goal.SetFromStringRepresentation(data);
                    return goal;
                }
            case "EternalGoal":
                {
                    EternalGoal goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goal.SetFromStringRepresentation(data);
                    return goal;
                }
            case "ChecklistGoal":
                {
                    ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                          int.Parse(parts[4]), int.Parse(parts[5]));
                    goal.SetFromStringRepresentation(data);
                    return goal;
                }
            default:
                return null;
        }
    }
}
