using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class MoveCommand : Command
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    public Vector3 TargetPosition => new Vector3(x, y, z);

    public MoveCommand(string executorID, Vector3 targetLocation) : base(executorID)
    {
        x = targetLocation.x;
        y = targetLocation.y;
        z = targetLocation.z;
    }

    public override void Execute()
    {
        GameObject _executorObject = Registry.GetObject(executorID);

        NavMeshAgent _navMeshAgent = _executorObject.GetComponent<NavMeshAgent>();
       
        _navMeshAgent.SetDestination(TargetPosition);

        WaitForPathComplete(_navMeshAgent);
    }

    private async void WaitForPathComplete(NavMeshAgent _navMeshAgent)
    {
        // Allow some time for the navMeshAgent to update its properties
        await Task.Delay(500);

        // Slow poll
        while (_navMeshAgent.pathPending || _navMeshAgent.hasPath)
            await Task.Delay(CommandManager.WaitingRate);

        isFinished = true;
    }
    public override void Abort()
    {
        Registry.GetObject(executorID).GetComponent<NavMeshAgent>().ResetPath();
        isFinished = true;
    }

    public override string ToString()
    {
        return $"Move Command: {TargetPosition}";
    }
}
