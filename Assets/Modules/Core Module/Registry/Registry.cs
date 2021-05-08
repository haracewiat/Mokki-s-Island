using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Registry 
{
    private static Dictionary<string, GameObject> gameObjectLookupTable; 

    public static GameObject GetObject(string id)
    {
        // TODO: try get
        return gameObjectLookupTable[id];
    }

    public static ObjectData GetObjectData(string id)
    {
        // TODO: try get
        ObjectData data = gameObjectLookupTable[id].GetComponent<Test>().ObjectData;
        Debug.Log($"[REGISTRY] {data}");
        return data;
    }

    public static void UpdateLookupTable(Dictionary<string, GameObject> updatedGameObjectLookupTable)
    {
        gameObjectLookupTable = updatedGameObjectLookupTable;
    }
}
