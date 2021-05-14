using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAction : Command  // Change to Action
{
    [SerializeField] private string seedID;
    [SerializeReference] private CommandsData commands = new CommandsData();

    public PlantAction(string executorID) : base(executorID)
    {
        Seed seed = Registry.LastClickedObject.transform.gameObject.GetComponent<Seed>();
        seedID = seed.ObjectData.ID;
    }

    public override void Execute() // ExecuteAll()?  -> see Entity class
    {
        //new MoveCommand(executorID, Registry.GetObjectData(seedID).TransformData.Position);
        commands.PushCommand(new MoveCommand(executorID, Registry.LastClickedObject.point));

        Debug.Log("Command for: Growing seed...");
        commands.PushCommand(new TestCommand(executorID));


        // Execute all commands...
        // commands.ExecuteAll();
        Command command = commands.PopCommand();
        command.Execute();

        // Wait for it to finish...
        commands.PopCommand().Execute();

        isFinished = true;
    }

    public override void Abort()
    {
        //throw new System.NotImplementedException();
    }
}
