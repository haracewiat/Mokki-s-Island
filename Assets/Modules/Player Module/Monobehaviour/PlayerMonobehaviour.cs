using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Text;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMonobehaviour : MonoBehaviour
{
    [Header("Monobehaviour")]
    [SerializeField] private NavMeshAgent _navMeshAgent;

    [Header("Internal")]
    [SerializeField] private Queue<Command> _commands = new Queue<Command>();
    [SerializeField] private bool _isCurrentlyExecuting;
    [SerializeField] private Command _currentCommand;

    private void Start()
    {
        // Set-up
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        // Events
        EventManager.SubscribeTo(EventID.Move, OnCommand);


    }

    private void OnCommand(object parameter)
    {
        // Check if I'm the executor

        // Add to the execute list 
        _commands.Enqueue((Command)parameter);

        // If not currently in execution, start executing
        if (!_isCurrentlyExecuting)
        {
            _isCurrentlyExecuting = true;
            StartCoroutine("ExecuteCommands");
        }


    }
    private IEnumerator ExecuteCommands()
    {
        // Iterate through the commands queue
        while (_commands.Count != 0) 
        {
            _currentCommand = _commands.Dequeue();
            
            _currentCommand.Execute();

            // Wait until the command finishes executing
            while (!_currentCommand.IsFinished())
                yield return null;
        }

        Debug.Log("Stopped executing");
        _isCurrentlyExecuting = false;
    }
}
