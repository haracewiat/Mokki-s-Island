using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMonobehaviour : Test
{
    [Header("Monobehaviour")]
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [Header("Internal")]
    [SerializeField] private List<Command> _commands = new List<Command>();
    [SerializeField] private bool _isCurrentlyExecuting;
    [SerializeField] private Command _currentCommand;
    [SerializeField] private bool stopExecuting = false;

    private void Start()
    {
        // Set-up
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        // Events
        EventManager.SubscribeTo(EventID.Move, OnCommand);
        EventManager.SubscribeTo(EventID.CommandCanceled, OnCommandCanceled);


        // Data
        //EventManager.SubscribeTo(EventID.DataLoaded, OnDataLoaded);
        //EventManager.NotifyAbout(EventID.DataRequested, "");
        Debug.Log(Registry.GetObject(objectData.ID));

    }

    //private void OnDataLoaded(object parameter)
    //{
    //    PlayerData _playerData = ((Data)parameter).PlayerData;
    //    transform.position = _playerData.TransformData.Position;
    //    //transform.rotation = _playerData.TransformData.Rotation;


    //}


    private void OnCommand(object parameter)
    {
        // Check if I'm the executor
        if (((MoveCommand)parameter).ExecutorID != objectData.ID) { return; }

        // Add to the execute list 
        _commands.Add((MoveCommand)parameter);
        objectData.CommandsData.PushCommand(new CommandData());


        // If not currently in execution, start executing
        if (!_isCurrentlyExecuting)
        {
            _isCurrentlyExecuting = true;
            StartCoroutine(ExecuteCommands());
        }
    }

    private void OnCommandCanceled(object parameter)
    {
        // Check if I'm the executor
        if (((MoveCommand)parameter) != _currentCommand) { return; }

        // Remove from the execute list 
        _commands.Remove((Command)parameter);
        objectData.CommandsData.PopCommand();

        // If currently executing, stop
        if (_currentCommand == (Command)parameter)
            stopExecuting = true;


    }

    private IEnumerator ExecuteCommands()
    {
        // Iterate through the commands queue
        while (_commands.Count != 0)
        {
            _currentCommand = _commands[0];

            //_commands.Remove(_currentCommand);

            _currentCommand.Execute();

            // Wait until the command finishes executing
            while (!_currentCommand.IsFinished())
            {
                if (!stopExecuting)
                    yield return null;
                else
                {
                    _currentCommand.Abort();
                    objectData.CommandsData.PopCommand();
                    stopExecuting = false;
                }
            }

            _commands.Remove(_currentCommand);
            objectData.CommandsData.PopCommand();
        }

        
        _isCurrentlyExecuting = false;
    }
}
