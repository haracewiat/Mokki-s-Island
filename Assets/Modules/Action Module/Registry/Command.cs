using UnityEngine;

[System.Serializable]
public abstract class Command 
{
    [SerializeField] protected string executorID;
    [SerializeField] protected bool isFinished;
    public string ExecutorID => executorID;
    public bool IsFinished => isFinished;

    public Command(string executorID)
    {
        this.executorID = executorID;
    }

    public abstract void Execute();
    public abstract void Abort();
}

