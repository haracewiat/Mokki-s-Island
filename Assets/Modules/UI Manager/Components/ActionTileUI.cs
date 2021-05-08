using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionTileUI : MonoBehaviour
{
    // Information about Command (must be initialized with one)
    private CommandData command;

    public string id;

    public void SetCommand(CommandData command)
    {
        this.command = command;
    }

    public void OnClick()
    {
        Debug.Log($"Clicked: {command}");
        EventManager.NotifyAbout(EventID.CommandCanceled, command);

        Destroy(gameObject);
    }
}
