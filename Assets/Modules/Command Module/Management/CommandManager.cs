using System;
using UnityEngine;

public class CommandManager : Manager<CommandManager>
{
    // TODO: move to system data
    public const int WaitingRate = 50;

    [SerializeField] private string currentExecutorID;

    // Dict with possible commands
    public bool toggle = true;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.CommandIssued, OnCommandDispatched);
    }

    private void OnCommandDispatched(object parameter)
    {
        EventManager.NotifyAbout(EventID.Move, new MoveCommand(data.GameData.CurrentExecutorID, ((RaycastHit)parameter).point));
    }
}
