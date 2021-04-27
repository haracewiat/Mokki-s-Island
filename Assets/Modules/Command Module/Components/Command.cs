using UnityEngine;

public abstract class Command 
{
    // Executor object?
    public MonoBehaviour _executor;

    public Command(MonoBehaviour executor)
    {
        _executor = executor;
    }

    public abstract bool IsFinished();
    public abstract void Execute();
}

