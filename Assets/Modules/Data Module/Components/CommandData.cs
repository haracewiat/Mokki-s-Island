using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class CommandData
{
    //[SerializeField] public string id;
    [SerializeField] protected string executorID;
    [SerializeField] private bool isFinished;

    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    public Vector3 TargetPosition => new Vector3(x, y, z);


    public string ExecutorID => executorID;

    public bool IsFinished => isFinished;

    public CommandData(string executorID, Vector3 targetLocation)
    {
        this.executorID = executorID;

        x = targetLocation.x;
        y = targetLocation.y;
        z = targetLocation.z;
    }

    public void Execute()
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



    public void Abort()
    {
        Registry.GetObject(executorID).GetComponent<NavMeshAgent>().ResetPath();
        isFinished = true;
    }

    public override string ToString()
    {
        return $"Move Command: {TargetPosition}";
    }
}