using UnityEngine;

[System.Serializable]
public class WalkAction : Action  
{

    public WalkAction(string executorID, string clickedObjectID, Vector3Data clickedPoint)
                    : base(executorID, clickedObjectID, clickedPoint)
    {
        // Declare variables
        Debug.Log("Walking...");

        // Declare commands
        commands.PushCommand(new MoveCommand(executorID, clickedPoint));
        //commands.PushCommand(new MoveCommand(executorID, new Vector3Data(Vector3.one)));
    }
}
