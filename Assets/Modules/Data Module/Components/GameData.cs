using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private string currentExecutorID;
    [SerializeField] private List<ObjectData> objectsData;

    public string CurrentExecutorID => currentExecutorID;
    public List<ObjectData> ObjectsData => objectsData;



}

[System.Serializable]
public class ObjectData
{
    [SerializeField] private string name;
    [SerializeField] private string id;
    [SerializeField] private GameObject prefab;
    [SerializeField] private TransformData transformData;
    [SerializeField] private ActionsData actionsData;
    [SerializeField] private CommandsData commandsData;



    public string ID => id;
    public GameObject Prefab => prefab;
    public TransformData TransformData => transformData;

    public ActionsData ActionsData => actionsData;
    public CommandsData CommandsData => commandsData;



    public void SetID(string id)
    {
        this.id = id;
    }

}