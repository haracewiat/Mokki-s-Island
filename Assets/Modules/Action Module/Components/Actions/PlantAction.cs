using UnityEngine;

public class PlantAction : Action  
{
    [SerializeField] private string seedID;

    public PlantAction(string executorID, string clickedObjectID, Vector3Data clickedPoint)
                     : base(executorID, clickedObjectID, clickedPoint)
    {
        // Declare variables
        seedID = clickedObjectID;
        Debug.Log($"[{GetType().Name}] Seed to plant: {seedID}");

        // Declare commands
        commands.PushCommand(new MoveCommand(executorID, clickedPoint));
        commands.PushCommand(new MoveCommand(executorID, new Vector3Data(Vector3.one)));
    }
}
