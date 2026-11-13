public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDisplayString()
    {
        return $"[ ] {_name} - {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name}:{_description}:{_points}";
    }
}
