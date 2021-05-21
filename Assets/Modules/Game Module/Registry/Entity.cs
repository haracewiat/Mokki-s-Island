[System.Serializable]
public abstract class Entity : Object
{
    public ActionsData actionsData; // BUG: [SerializeField] private causes inde out of range?
    // TODO: Add Inventory data to Entity class

    public Entity(ObjectData objectData) : base(objectData) { }

    public void AssignAction(Action action)
    {
        actionsData.AssignAction(action);
    }
}
