using System;
using UnityEngine;

public class ActionManager : Manager<ActionManager>
{
    // TODO: move to system data
    public const int WaitingRate = 50;

    [SerializeField] private string currentExecutorID;

    // Dict with possible commands
    public bool toggle = true;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.CommandIssued, OnCommandIssued);
    }

    private void OnCommandIssued(object parameter)
    {
        // Get the clicked object
        GameObject clickedObject = Registry.LastClickedObject.transform.gameObject;
        ActionID actionID = Registry.LastChosenAction;

        // Fire a relevant action (ActionID == name of the action class)
        Type type = Type.GetType(actionID.ToString());
        object action = Activator.CreateInstance(type, new object[] { data.GameData.CurrentExecutorID });
        EventManager.NotifyAbout(EventID.Move, action);
    }
}
