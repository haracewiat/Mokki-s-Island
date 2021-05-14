using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class CommandsData
{
    [SerializeReference] private List<Command> commands = new List<Command>();

    public List<Command> Commands => commands;

    public void PushCommand(Command command) { commands.Add(command); }

    public Command PopCommand()
    {
        Command command = commands[0];
        commands.RemoveAt(0);

        return command;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Command command in commands)
            sb.AppendLine(command.ToString());

        return sb.ToString();
    }

}