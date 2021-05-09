using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Registry 
{
    private static Dictionary<string, GameObject> gameObjectLookupTable;
    private static Data data;

    public static Data Data => data;

    public static GameObject GetObject(string id)
    {
        // TODO: try get
        return gameObjectLookupTable[id];
    }

    public static ObjectData GetObjectData(string id)
    {
        // TODO: try get
        ObjectData objectData = gameObjectLookupTable[id].GetComponent<Entity>().ObjectData;

        objectData = data.GameData.ObjectsData.Find(x => x.ID == id);
        return objectData;
    }

    public static void UpdateLookupTable(Dictionary<string, GameObject> updatedGameObjectLookupTable)
    {
        gameObjectLookupTable = updatedGameObjectLookupTable;
    }

    public static void UpdateData(Data updatedData)
    {
        data = updatedData;
    }
}
