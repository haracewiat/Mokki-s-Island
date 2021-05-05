using UnityEngine;

[System.Serializable]
public abstract class Command 
{
    [SerializeField] protected string executorID;

    public string ExecutorID => executorID;

    public Command(string executorID)
    {
        this.executorID = executorID;
    }

    public abstract bool IsFinished();
    public abstract void Execute();
    public abstract void Abort();

}

