using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Action
{
    [SerializeField] protected string executorID;
    [SerializeField] protected bool isFinished;
    public string ExecutorID => executorID;
    public bool IsFinished => isFinished;

    public Action(string executorID)
    {
        this.executorID = executorID;
    }

    public abstract void Execute();
    public abstract void Abort();
}