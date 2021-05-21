using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class Action
{
    [SerializeField] protected string executorID;
    [SerializeField] protected string clickedObjectID;
    [SerializeField] protected Vector3Data clickedPoint;

    [SerializeReference] protected CommandsData commands = new CommandsData();
    [SerializeField] protected Command currentCommand;

    [SerializeField] protected bool isFinished;    

    public string ExecutorID => executorID;
    public bool IsFinished => isFinished;

    public Action(string executorID, string clickedObjectID, Vector3Data clickedPoint)
    {
        this.executorID = executorID;
        this.clickedObjectID = clickedObjectID;
        this.clickedPoint = clickedPoint;
    }

    public async void Execute() {

        Debug.Log($"[{GetType().Name}] Starting to execute commands...");

        // Iterate through the commands queue
        while (commands.Commands.Count != 0)
        {
            currentCommand = commands.Commands[0];

            Debug.Log($"Current command: {currentCommand}");

            currentCommand.Execute();

            // Wait until the command finishes executing
            while (!currentCommand.IsFinished)
            {
                Debug.Log($"[{GetType().Name}] Waiting..."); // BUG: Async doesn't stop running when game is stopped
                await Task.Delay(ActionManager.WaitingRate); // TODO: Move Waiting Rate to Registry/data
            }

            commands.PopCommand();
        }

        isFinished = true;
    }
    public void Abort() {
        currentCommand.Abort();
        isFinished = true;    
    }
}