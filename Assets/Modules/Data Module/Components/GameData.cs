using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private string currentExecutorID;
    [SerializeField] private List<ObjectData> objectsData;

    public string CurrentExecutorID => currentExecutorID;
    public List<ObjectData> ObjectsData => objectsData;

    public void SetCurrentExecutorID (string executorID)
    {
        currentExecutorID = executorID;
        EventManager.NotifyAbout(EventID.ExecutorChanged, currentExecutorID);
    }


}
