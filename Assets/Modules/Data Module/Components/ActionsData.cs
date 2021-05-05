using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionsData
{
    [SerializeField] private List<ActionData> actions;

    public List<ActionData> Actions => actions;

    // Get Current Action? 

    // ExecuteAll

    // Abort

}

// Change to scriptable object?
[System.Serializable]
public class ActionData
{
    [SerializeField] public string id; // Type of the command 
    [SerializeField] private List<CommandData> commands;
}



// TODO: REMOVE
[System.Serializable]
public class CommandsData
{
    [SerializeField] private List<CommandData> commands;

    [SerializeField] public List<CommandData> Commands => commands;

    public void PushCommand(CommandData commandData)
    {
        commands.Add(commandData);
    }

    public CommandData PopCommand()
    {
        CommandData commandData = commands[0];
        commands.RemoveAt(0);

        return commandData;
    }

}