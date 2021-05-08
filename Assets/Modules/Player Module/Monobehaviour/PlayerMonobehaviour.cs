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

    [SerializeField] private CommandData currentCommand;

    [SerializeField] private bool stopExecuting = false;


    // Temp
    LineRenderer lineRenderer;

    private void Start()
    {
        // Set-up
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        lineRenderer = gameObject.GetComponent<LineRenderer>();



        // Events
        EventManager.SubscribeTo(EventID.Move, OnCommand);
        EventManager.SubscribeTo(EventID.CommandCanceled, OnCommandCanceled);
        EventManager.SubscribeTo(EventID.ExecutorChanged, OnExecutorChanged);



        // Data
        //EventManager.SubscribeTo(EventID.DataLoaded, OnDataLoaded);
        //EventManager.NotifyAbout(EventID.DataRequested, "");
        Debug.Log(Registry.GetObject(objectData.ID));

        // Execute commands if any found
        if (objectData.CommandsData.Commands.Count > 0)
        {
            if (!_isCurrentlyExecuting)
            {
                _isCurrentlyExecuting = true;
                StartCoroutine(ExecuteCommands());
            }
        }

    }

    //private void OnDataLoaded(object parameter)
    //{
    //    PlayerData _playerData = ((Data)parameter).PlayerData;
    //    transform.position = _playerData.TransformData.Position;
    //    //transform.rotation = _playerData.TransformData.Rotation;


    //}
    private void Update()
    {
        DrawLine();
    }
    private void DrawLine()
    {
        lineRenderer.positionCount = _navMeshAgent.path.corners.Length;
        lineRenderer.SetPositions(_navMeshAgent.path.corners);
    }

    private void OnExecutorChanged(object parameter)
    {
        // Check if I was selected
        if ((string)parameter == objectData.ID) {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    private void OnCommand(object parameter)
    {
        // Check if I'm the executor
        Debug.Log($"1: {((CommandData)parameter).ExecutorID} == {objectData.ID}");
        if (((CommandData)parameter).ExecutorID != objectData.ID) { return; }
        Debug.Log("2");

        // Add to the execute list 
        //_commands.Add((MoveCommand)parameter);
        objectData.CommandsData.PushCommand((CommandData)parameter);


        // If not currently in execution, start executing
        if (!_isCurrentlyExecuting)
        {
            _isCurrentlyExecuting = true;
            StartCoroutine(ExecuteCommands());
        }
    }

    private void OnCommandCanceled(object parameter)
    {
        Debug.Log($"Command canceled: {((CommandData)parameter)}");
        // Check if I'm the executor
        if (((CommandData)parameter).ExecutorID != objectData.ID) { return; }

        // If currently executing, stop
        if ((((CommandData)parameter) == currentCommand) && _isCurrentlyExecuting)
            stopExecuting = true;
        else
        {
            // Remove from the execute list 
            objectData.CommandsData.PopCommand();
        }

    }

    private IEnumerator ExecuteCommands()
    {
        // Iterate through the commands queue
        //while (_commands.Count != 0)
        while (objectData.CommandsData.Commands.Count != 0)
        {
            //_currentCommand = _commands[0];
            currentCommand = objectData.CommandsData.Commands[0];

            //_currentCommand.Execute();
            currentCommand.Execute();

            // Wait until the command finishes executing
            while (!currentCommand.IsFinished)
            {
                if (!stopExecuting)
                    yield return null;
                else
                {
                    currentCommand.Abort();
                    stopExecuting = false;
                }
            }

            //_commands.Remove(_currentCommand);
            objectData.CommandsData.PopCommand();
        }

        currentCommand = null;

        _isCurrentlyExecuting = false;
    }
}
