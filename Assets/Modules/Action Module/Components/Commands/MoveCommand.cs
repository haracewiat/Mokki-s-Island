using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class MoveCommand : Command
{
    [SerializeField] private Vector3Data destination;

    public MoveCommand(string executorID) : base(executorID)
    {
        this.destination = new Vector3Data(Registry.LastClickedObject.point);
    }

    public MoveCommand(string executorID, Vector3 destination) : base(executorID)
    {
        this.destination = new Vector3Data(destination);
    }

    public override void Execute()
    {
        GameObject _executorObject = Registry.GetObject(executorID);

        NavMeshAgent _navMeshAgent = _executorObject.GetComponent<NavMeshAgent>();
       
        _navMeshAgent.SetDestination(destination.Vector3);

        WaitForPathComplete(_navMeshAgent);
    }

    private async void WaitForPathComplete(NavMeshAgent _navMeshAgent)
    {
        // Allow some time for the navMeshAgent to update its properties
        await Task.Delay(500);

        // Slow poll
        while (_navMeshAgent.pathPending || _navMeshAgent.hasPath)
            await Task.Delay(ActionManager.WaitingRate);

        isFinished = true;
    }
    public override void Abort()
    {
        Registry.GetObject(executorID).GetComponent<NavMeshAgent>().ResetPath();
        isFinished = true;
    }

    public override string ToString()
    {
        return $"Move Command: {destination.Vector3}";
    }
}
