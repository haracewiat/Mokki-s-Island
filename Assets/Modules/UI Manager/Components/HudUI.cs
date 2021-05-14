using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


// Change to UI instead of Manager
public class HudUI : Manager<HudUI>
{
    // Actions panel UI
    [Header("Prefabs")]
    [SerializeField] private RectTransform actionsPanel;
    [SerializeField] private ActionTileUI actionTile;   // prefab

    [Header("Data")]
    //[SerializeField] private List<ActionData> actions = new List<ActionData>(); // reference to all commands 
    ActionTileUI newAction;

    [SerializeField] private List<Command> actions = new List<Command>(); // reference to all commands 


    //[Header("Internal")]
    [SerializeField] private RectTransform commandsPanel;
    [SerializeField] private ActionTIleTEST button;
    private ActionTIleTEST newCommand;


    protected override void Init()
    {
        InvokeRepeating("UpdateDisplay", 0, 0.5f); // TODO: instead of every 0.5 s, subscribe to any update to this variable

        EventManager.SubscribeTo(EventID.ObjectClicked, OnObjectClicked);
    }

    private void UpdateDisplay()
    {
        // Clear the panel
        actions = Registry.GetObjectData(data.GameData.CurrentExecutorID).CommandsData.Commands;

        for (int i = 0; i < actionsPanel.transform.childCount; i++)
            Destroy(actionsPanel.transform.GetChild(i).gameObject); // TODO: Object polling (rewrite), e.g max tiles number

        // Fill the panel with updated actions
        foreach (Command action in actions)
        {
            newAction = Instantiate(actionTile);
            newAction.SetCommand(action);
            newAction.transform.SetParent(actionsPanel);
        }
    }





    // ------------------------------------

    // On
    private void OnObjectClicked(object parameter)
    {
        // Get the clicked object
        GameObject clickedObject = Registry.LastClickedObject.transform.gameObject;

        InteractableObject interactableObject;
        if (!clickedObject.TryGetComponent(out interactableObject)) { return; }

        // Read action associated with it
        List<ActionID> actions = interactableObject.ActionSet.Actions;

        // Clean the actions panel
        for (int i = 1; i < commandsPanel.transform.childCount; i++)
            Destroy(commandsPanel.transform.GetChild(i).gameObject);

        // For each action, create a button
        foreach (ActionID actionID in actions)
        {
            newCommand = Instantiate(button);
            newCommand.gameObject.SetActive(true);
            newCommand.transform.SetParent(commandsPanel);
            newCommand.SetActionID(actionID);
        }
    }
}