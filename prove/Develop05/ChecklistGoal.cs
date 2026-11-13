public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, 
                         int targetAmount, int bonusPoints) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int earnedPoints = _points;
        
        if (_amountCompleted == _targetAmount)
        {
            earnedPoints += _bonusPoints;
        }
        
        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public override string GetDisplayString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} - Completed {_amountCompleted}/{_targetAmount} times";
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTargetAmount()
    {
        return _targetAmount;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name}:{_description}:{_points}:{_targetAmount}:{_bonusPoints}:{_amountCompleted}";
    }

    public override void SetFromStringRepresentation(string data)
    {
        string[] parts = data.Split(":");
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _targetAmount = int.Parse(parts[4]);
        _bonusPoints = int.Parse(parts[5]);
        _amountCompleted = int.Parse(parts[6]);
    }
}
