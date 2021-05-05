using System;
using UnityEngine;

public class CommandManager : Manager<CommandManager>
{
    // TODO: move to system data
    public const int WaitingRate = 50;

    // TODO: From data get current executor
    //[SerializeField] MonoBehaviour currentExecutor;
    [SerializeField] private string currentExecutorID;


    // Dict with possible commands

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.CommandDispatched, OnCommandDispatched);

        currentExecutorID = data.GameData.CurrentExecutorID;
    }

    private void OnCommandDispatched(object parameter)
    {
        EventManager.NotifyAbout(EventID.Move, new MoveCommand(currentExecutorID, ((RaycastHit)parameter).point));
    }
}
