using System.Collections;
using UnityEngine;

// TODO: rename to entity? class that deals with object data (entity data?)
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected ObjectData objectData;

    [SerializeField] private bool _isCurrentlyExecuting;
    [SerializeField] private Command currentCommand;
    [SerializeField] private bool stopExecuting = false;

    public ObjectData ObjectData => objectData;

    public void SetData(ObjectData objectData)
    {
        this.objectData = objectData;

        transform.position = objectData.TransformData.Position;
        transform.rotation = objectData.TransformData.Rotation;

        Init();
    }

    private void Start()
    {
        // Events
        EventManager.SubscribeTo(EventID.Move, OnCommand);
        EventManager.SubscribeTo(EventID.CommandCanceled, OnCommandCanceled);

        // Execute commands if any found
        if (Registry.GetObjectData(objectData.ID).CommandsData.Commands.Count > 0)
        {
            if (!_isCurrentlyExecuting)
            {
                StartCoroutine(ExecuteCommands());
            }
        }
    }

    private void OnCommand(object parameter)
    {
        // Check if I'm the executor
        if (((Command)parameter).ExecutorID != objectData.ID) { return; }

        // Add to the execute list 
        //_commands.Add((MoveCommand)parameter);
        Registry.GetObjectData(objectData.ID).CommandsData.PushCommand((Command)parameter);


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
        if (((Command)parameter).ExecutorID != objectData.ID) { return; }

        // If currently executing, stop
        if ((((Command)parameter) == currentCommand) && _isCurrentlyExecuting)
            stopExecuting = true;
        else
        {
            // Remove from the execute list 
            Registry.GetObjectData(objectData.ID).CommandsData.PopCommand();
        }

    }

    private IEnumerator ExecuteCommands()
    {
        _isCurrentlyExecuting = true;

        // Iterate through the commands queue
        while (Registry.GetObjectData(objectData.ID).CommandsData.Commands.Count != 0)
        {
            //_currentCommand = _commands[0];
            currentCommand = Registry.GetObjectData(objectData.ID).CommandsData.Commands[0];

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
            Registry.GetObjectData(objectData.ID).CommandsData.PopCommand();
        }

        currentCommand = null;

        _isCurrentlyExecuting = false;
    }

    protected abstract void Init();

}
