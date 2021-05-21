using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private string currentExecutorID;
    [SerializeField] private List<ObjectData> objectsData;

    [Header("Temporary")] // TODO: Change to generic object data (property drawer?...)
    [SerializeField] private List<Ground> groundsData;
    [SerializeField] private List<Seed> seedsData;
    [SerializeField] private List<Player> playersData;


    public string CurrentExecutorID => currentExecutorID;
    public List<ObjectData> ObjectsData => objectsData;

    public List<Ground> GroundsData => groundsData;
    public List<Seed> SeedsData => seedsData;
    public List<Player> PlayersData => playersData;


    // TODO: Remove temporary function
    public List<Object> GetObjects()
    {
        List<Object> list = new List<Object>();

        list.AddRange(groundsData);
        list.AddRange(seedsData);
        list.AddRange(playersData);

        return list;
    }

    public void SetCurrentExecutorID (string executorID)
    {
        currentExecutorID = executorID;
        EventManager.NotifyAbout(EventID.ExecutorChanged, currentExecutorID);
    }


}
