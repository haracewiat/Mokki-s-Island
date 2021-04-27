using System;
using UnityEngine;

public class CommandManager : Manager<CommandManager>
{
    public const int WaitingRate = 50;        
    public PlayerMonobehaviour player;



    private void Start()
    {
        EventManager.SubscribeTo(EventID.CommandDispatched, OnCommandDispatched);
    }

    private void OnCommandDispatched(object parameter)
    {
        // Check registry: what command is assigned to the hit object?
        // e.g. Terrain => Move

        EventManager.NotifyAbout(EventID.Move, new MoveCommand(player, ((RaycastHit)parameter).point));

    }
}
