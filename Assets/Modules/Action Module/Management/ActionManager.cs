using System;
using UnityEngine;

public class ActionManager : Manager<ActionManager>
{
    // TODO: Move Waiting Rate (slow poll rate) to System data
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

        // TODO: Refactor function OnCommandIssued in Action Manager

        // Get the clicked object
        // Object clickedObject = Registry.LastClickedObject.transform.gameObject.GetComponent<Object>();

        // Get ID of the executor (from registry)
        string currentExecutorID = data.GameData.CurrentExecutorID;

        // Get ID of the clicked object (know the clicked monobehaviour -> look up its id)
        GameObject clickedObject = Registry.LastClickedObject.transform.gameObject;
        string clickedObjectID = Registry.MonobehaviourLookupTable[clickedObject];

        Vector3Data clickedPoint = new Vector3Data(Registry.LastClickedObject.point);
        ActionID actionID = Registry.LastChosenAction;

        // Fire a relevant action (ActionID == name of the action class)
        Type type = Type.GetType(actionID.ToString());
        // object[] parameters = new object[] { data.GameData.CurrentExecutorID, clickedObject.ObjectData.ID, clickedPoint};
        object[] parameters = new object[] { currentExecutorID, clickedObjectID, clickedPoint };

        Action action = (Action)Activator.CreateInstance(type, parameters);

        // Assign action to the current executor's Entity
        // EventManager.NotifyAbout(EventID.Move, action);
        Entity currentExecutorEntity = (Entity)Registry.ObjectLookupTable[currentExecutorID];
        currentExecutorEntity.AssignAction(action);
    }
}
