using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private bool _isFinished = false;
    private Vector3 _targetLocation;

    NavMeshAgent _navMeshAgent;

    public MoveCommand(string executorID, Vector3 targetLocation) : base(executorID)
    {
        _targetLocation = targetLocation;
    }

    public override void Execute()
    {
        Debug.Log(executorID);
        GameObject _executorObject = Registry.GetObject(executorID);

        _navMeshAgent = _executorObject.GetComponent<NavMeshAgent>();

        _navMeshAgent.SetDestination(_targetLocation);

        WaitForPathComplete();
    }

    public override bool IsFinished()
    {
        return _isFinished;
    }

    private async void WaitForPathComplete()
    {
        // Allow some time for the navMeshAgent to update its properties
        await Task.Delay(500);

        // Slow poll
        while (_navMeshAgent.pathPending || _navMeshAgent.hasPath)
            await Task.Delay(CommandManager.WaitingRate);

        _isFinished = true;
    }

    public override void Abort()
    {
        _navMeshAgent.ResetPath();
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {_targetLocation}";
    }
}
