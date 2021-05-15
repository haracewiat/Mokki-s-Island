using System.Collections;
using UnityEngine;

public abstract class Entity : InteractableObject
{
    [SerializeField] private Action currentAction;

    [SerializeField] private bool _isCurrentlyExecuting;
    [SerializeField] private bool stopExecuting = false;


    private void Start()
    {
        // Events
        EventManager.SubscribeTo(EventID.Move, OnAction);
        EventManager.SubscribeTo(EventID.CommandCanceled, OnActionCanceled);

        // Execute commands if any found
        if (Registry.GetObjectData(objectData.ID).ActionsData.Actions.Count > 0)
        {
            if (!_isCurrentlyExecuting)
            {
                StartCoroutine(ExecuteActions());
            }
        }
    }

    private void OnAction(object parameter)
    {
        // Check if I'm the executor
        if (((Action)parameter).ExecutorID != objectData.ID) { return; }

        // Add to the execute list 
        Registry.GetObjectData(objectData.ID).ActionsData.PushAction((Action)parameter);


        // If not currently in execution, start executing
        if (!_isCurrentlyExecuting)
        {
            _isCurrentlyExecuting = true;
            StartCoroutine(ExecuteActions());
        }
    }

    private void OnActionCanceled(object parameter)
    {
        // Check if I'm the executor
        if (((Action)parameter).ExecutorID != objectData.ID) { return; }

        // If currently executing, stop
        if ((((Action)parameter) == currentAction) && _isCurrentlyExecuting)
            stopExecuting = true;
        else
        {
            // Remove from the execute list 
            Registry.GetObjectData(objectData.ID).ActionsData.PopAction();
        }

    }

    private IEnumerator ExecuteActions()
    {
        _isCurrentlyExecuting = true;

        // Iterate through the commands queue
        while (Registry.GetObjectData(objectData.ID).ActionsData.Actions.Count != 0)
        {
            currentAction = Registry.GetObjectData(objectData.ID).ActionsData.Actions[0];

            currentAction.Execute();

            // Wait until the command finishes executing
            while (!currentAction.IsFinished)
            {
                Debug.Log("...");
                
                if (!stopExecuting)
                    yield return null;
                else
                {
                    currentAction.Abort();
                    stopExecuting = false;
                }
            }

            //_commands.Remove(_currentAction);
            Registry.GetObjectData(objectData.ID).ActionsData.PopAction();
        }

        currentAction = null;

        _isCurrentlyExecuting = false;
    }

}
