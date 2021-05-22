using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionTileUI : MonoBehaviour
{
    // Information about Command (must be initialized with one)
    private Command command;

    public string id;

    public void SetCommand(Command command)
    {
        this.command = command;
    }

    public void OnClick()
    {
        Debug.Log($"Clicked: {command}");
        // TODO: which command cancelled? -> actions data should know...
        EventManager.NotifyAbout(EventID.CommandCanceled);

        Destroy(gameObject);
    }
}
