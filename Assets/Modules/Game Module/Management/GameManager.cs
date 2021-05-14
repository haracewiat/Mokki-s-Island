using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{

    // Actual data from data manager
    [SerializeField] private Dictionary<string, ObjectData> objectsDataTable = new Dictionary<string, ObjectData>(); // id => all data
        
    // id => gameobject (instantiated gameobjects)
    [SerializeField] private Dictionary<string, GameObject> gameObjectLookupTable = new Dictionary<string, GameObject>(); // id => actual gameobject


    private bool flag = true;
    private int index = 0;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.Space, OnSpace);

        OnSpace(0);
    }

    private void OnSpace(object parameter)
    {
        index += 1;
        index %= gameObjectLookupTable.Count;

        Debug.Log($"Object count: {gameObjectLookupTable.Count} \nCurrent index: {index}");
        data.GameData.SetCurrentExecutorID(data.GameData.ObjectsData[index].ID);
    }


    // TODO change to DataChanged 
    protected override void OnDataLoaded(object parameter)
    {
        base.OnDataLoaded(parameter);
        // Get Game Data from data object 
        /* 
         * Game Data: objects data : prefab, inventory, stats, transform...
         */

        // TODO: only on gamedata changed
        if (flag)
        {
            foreach (ObjectData objectData in data.GameData.ObjectsData)
            {

                // Generate unique ID if none is present (TODO: mvoe to objectData constructor)
                if (objectData.ID == string.Empty)
                    objectData.SetID(Guid.NewGuid().ToString());

                // Create object instance and inject corresponding data (TODO: cleaner solution)
                //GameObject gameObjectInstance = Instantiate(objectData.Prefab) as GameObject;
                GameObject gameObjectPrefab = Resources.Load(objectData.PrefabID) as GameObject;
                GameObject gameObjectInstance = Instantiate(gameObjectPrefab);
                gameObjectInstance.GetComponent<Entity>().SetData(objectData); 

                // Store in the lookup table
                gameObjectLookupTable.Add(objectData.ID, gameObjectInstance);

            }

            Registry.UpdateLookupTable(gameObjectLookupTable);

            flag = false;
        }

    }


}
