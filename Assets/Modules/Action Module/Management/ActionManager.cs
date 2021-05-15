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
        Object clickedObject = Registry.LastClickedObject.transform.gameObject.GetComponent<Object>();
        Vector3Data clickedPoint = new Vector3Data(Registry.LastClickedObject.point);
        ActionID actionID = Registry.LastChosenAction;

        // Fire a relevant action (ActionID == name of the action class)
        Type type = Type.GetType(actionID.ToString());
        object[] parameters = new object[] { data.GameData.CurrentExecutorID, clickedObject.ObjectData.ID, clickedPoint};

        object action = Activator.CreateInstance(type, parameters);
        EventManager.NotifyAbout(EventID.Move, action);
    }
}
