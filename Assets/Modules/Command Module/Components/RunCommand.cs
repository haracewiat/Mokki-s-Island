using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RunCommand : Command
{
    [SerializeField] private string name = "Run Command";
    public RunCommand(string executorID, Vector3 targetLocation) : base(executorID)
    {

    }

    public override void Abort()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
