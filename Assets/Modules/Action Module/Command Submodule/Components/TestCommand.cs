using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class TestCommand : Command
{

    public TestCommand(string executorID) : base(executorID) { }

    public override void Execute()
    {
        GameObject _executorObject = Registry.GetObject(executorID);

        WaitForCommandComplete();
    }

    private async void WaitForCommandComplete()
    {
        Debug.Log("Test command started...");

        await Task.Delay(2000);

        Debug.Log("Test command finished.");

        isFinished = true;
    }

    public override void Abort()
    {
        Debug.Log("Test command aborted.");
        isFinished = true;
    }
}
