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

    public static void UpdateLookupTable(Dictionary<string, GameObject> updatedGameObjectLookupTable)
    {
        gameObjectLookupTable = updatedGameObjectLookupTable;
    }
}
