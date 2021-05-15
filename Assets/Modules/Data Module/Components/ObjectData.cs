using UnityEngine;

[System.Serializable]
public class ObjectData
{
    [SerializeField] private string name;
    [SerializeField] private string id;
    [SerializeField] private string prefabID;
    [SerializeField] private TransformData transformData;
    [SerializeField] private ActionsData actionsData;
    [SerializeField] private CommandsData commandsData;



    public string ID => id;
    public string PrefabID => prefabID;
    public TransformData TransformData => transformData;

    public ActionsData ActionsData => actionsData;
    public CommandsData CommandsData => commandsData;



    public void SetID(string id)
    {
        this.id = id;
    }

    public override string ToString()
    {
        return commandsData.ToString();
    }

}