using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Registry 
{
    // All data
    private static Data data;

    // id - monobehaviour
    private static Dictionary<string, GameObject> gameObjectLookupTable;

    // last clicked object
    private static RaycastHit lastClickedObject;
    // last chosen action
    private static ActionID lastChosenAction;



    public static Data Data => data;
    public static RaycastHit LastClickedObject => lastClickedObject;
    public static ActionID LastChosenAction => lastChosenAction;


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

    public static void UpdateLastClickedObject(RaycastHit updatedRaycastHit)
    {
        lastClickedObject = updatedRaycastHit;
        EventManager.NotifyAbout(EventID.ObjectClicked, lastClickedObject);
        Debug.Log($"[UpdateLastClickedObject]: {updatedRaycastHit.transform.gameObject}");
    }

    public static void UpdateLastChosenAction(ActionID actionID)
    {
        lastChosenAction = actionID;
        Debug.Log($"[UpdateLastChosenAction]: {actionID}");
    }
}
