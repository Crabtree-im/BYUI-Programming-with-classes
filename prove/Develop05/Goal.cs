public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();
    
    public abstract bool IsComplete();
    
    public abstract string GetDisplayString();

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name}:{_description}:{_points}";
    }

    public virtual void SetFromStringRepresentation(string data)
    {
        string[] parts = data.Split(":");
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
    }
}
