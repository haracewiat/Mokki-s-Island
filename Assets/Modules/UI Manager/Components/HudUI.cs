using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private List<CommandData> actions = new List<CommandData>(); // reference to all commands 


    [Header("Internal")]
    [SerializeField] private string currentExecutorID;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.CommandDispatched, OnCommandDispatched);
        // Listen to current Executor ID changed

        currentExecutorID = data.GameData.CurrentExecutorID;

        actions = data.GameData.ObjectsData[0].CommandsData.Commands;
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void OnCommandDispatched(object parameter)
    {
       



        //UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        // Clear the panel
        for (int i = 0; i < actionsPanel.transform.childCount; i++)
            Destroy(actionsPanel.transform.GetChild(i).gameObject); // TODO: Object polling (rewrite), e.g max tiles number

        // Fill the panel with updated actions
        foreach (CommandData actionData in actions)
        {
            newAction = Instantiate(actionTile);
            newAction.SetCommand(actionData.ToString());
            newAction.transform.SetParent(actionsPanel);
        }
    }
}
