using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class ActionsData
{
    [SerializeField] private List<Action> actions;

    public List<Action> Actions => actions;

    // Get Current Action? 

    // ExecuteAll

    // Abort

}

// Change to scriptable object?
[System.Serializable]
public class Action
{
    [SerializeField] public string id; // Type of the command 
    [SerializeField] private List<Command> commands;
}
