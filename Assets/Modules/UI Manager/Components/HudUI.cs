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

    [SerializeField] private List<Command> actions = new List<Command>(); // reference to all commands 


    //[Header("Internal")]
    //[SerializeField] private string currentExecutorID;

    protected override void Init()
    {
        InvokeRepeating("UpdateDisplay", 0, 0.5f);
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
}
