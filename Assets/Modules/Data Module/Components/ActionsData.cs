using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class ActionsData
{
    [SerializeReference] public List<Action> actions; 
    [SerializeReference] private Action currentAction;

    [SerializeField] private bool _isCurrentlyExecuting;
    [SerializeField] private bool stopExecuting = false;


    public List<Action> Actions => actions;

    public void PushAction(Action action) { actions.Add(action); }

    public Action PopAction()
    {
        Action action = actions[0];
        actions.RemoveAt(0);

        return action;
    }

    // *******************************************************

    public void AssignAction(Action action)
    {
        // Add to the execute list 
        PushAction(action);


        // If not currently in execution, start executing
        if (!_isCurrentlyExecuting)
        {
            _isCurrentlyExecuting = true;
            Registry.GetGameObject(action.ExecutorID).GetComponent<MonoBehaviour>().StartCoroutine(ExecuteActions());
        }
    }

    private IEnumerator ExecuteActions()
    { 
        _isCurrentlyExecuting = true;

        // Iterate through the commands queue
        while (actions.Count != 0)
        {
            currentAction = actions[0];

            currentAction.Execute();

            // Wait until the command finishes executing
            while (!currentAction.IsFinished)
            {
                if (!stopExecuting)
                    yield return null;
                else
                {
                    currentAction.Abort();
                    stopExecuting = false;
                }
            }

            PopAction();
        }

        currentAction = null;

        _isCurrentlyExecuting = false;
    }


    //private void OnActionCanceled(object parameter)
    //{
    //    // Check if I'm the executor
    //    if (((Action)parameter).ExecutorID != objectData.ID) { return; }

    //    // If currently executing, stop
    //    if ((((Action)parameter) == currentAction) && _isCurrentlyExecuting)
    //        stopExecuting = true;
    //    else
    //    {
    //        // Remove from the execute list 
    //        Registry.GetObjectData(objectData.ID).ActionsData.PopAction();
    //    }

    //}

    // *******************************************************

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Action action in actions)
            sb.AppendLine(action.ToString());

        return sb.ToString();
    }

}


