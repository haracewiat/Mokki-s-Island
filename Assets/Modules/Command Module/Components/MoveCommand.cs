using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private bool _isFinished = false;
    private Vector3 _targetLocation;

    NavMeshAgent _navMeshAgent;

    public MoveCommand(MonoBehaviour executor, Vector3 targetLocation) : base(executor)
    {
        _targetLocation = targetLocation;
    }

    public override void Execute()
    {
        Debug.Log($"{_targetLocation} will be executed now!");

        _navMeshAgent = _executor.GetComponent<NavMeshAgent>();
        
        _navMeshAgent.SetDestination(_targetLocation);
        
        WaitForPathComplete();
    }

    public override bool IsFinished()
    {
        return _isFinished;
    }

    private async void WaitForPathComplete()
    {
        while (_navMeshAgent.pathPending || _navMeshAgent.hasPath)
            await Task.Delay(CommandManager.WaitingRate);

        _isFinished = true;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {_targetLocation}";
    }
}
