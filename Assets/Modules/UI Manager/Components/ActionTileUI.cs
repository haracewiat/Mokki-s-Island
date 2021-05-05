using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionTileUI : MonoBehaviour
{
    // Information about Command (must be initialized with one)
    private MoveCommand command;

    public string id;

    public void SetCommand(MoveCommand command)
    {
        this.command = command;
    }

    public void SetCommand(string id)
    {
        this.id = id;
    }

    public void OnClick()
    {
        EventManager.NotifyAbout(EventID.CommandCanceled, command);

        Destroy(gameObject);
    }
}
