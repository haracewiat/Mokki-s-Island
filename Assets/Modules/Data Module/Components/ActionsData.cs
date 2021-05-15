using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class ActionsData
{
    [SerializeField] private List<Action> actions = new List<Action>();

    public List<Action> Actions => actions;

    // Get Current Action? 

    // ExecuteAll

    // Abort

    public void PushAction(Action action) { actions.Add(action); }

    public Action PopAction()
    {
        Action action = actions[0];
        actions.RemoveAt(0);

        return action;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Action action in actions)
            sb.AppendLine(action.ToString());

        return sb.ToString();
    }

}


