using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Registry 
{
    // All data
    private static SaveData data;

    // id - monobehaviour
    private static Dictionary<string, GameObject> gameObjectLookupTable = new Dictionary<string, GameObject>();

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
        ObjectData objectData = gameObjectLookupTable[id].GetComponent<Object>().ObjectData;

        objectData = data.GameData.ObjectsData.Find(x => x.ID == id);
        return objectData;
    }

    public static void UpdateLookupTable(Dictionary<string, GameObject> updatedGameObjectLookupTable)
    {
        gameObjectLookupTable = updatedGameObjectLookupTable;
    }

    public static void UpdateData(SaveData updatedData)
    {
        data = updatedData;
    }

    public static void UpdateLastClickedObject(RaycastHit updatedRaycastHit)
    {
        lastClickedObject = updatedRaycastHit;
        EventManager.NotifyAbout(EventID.ObjectClicked);
    }

    public static void UpdateLastChosenAction(ActionID actionID)
    {
        lastChosenAction = actionID;
    }

    public static void RegisterGameObject(string ID, GameObject gameObject)
    {
        gameObjectLookupTable.Add(ID, gameObject);
    }



    // --------------------------------------------------
    public static Dictionary<string, Object> ObjectLookupTable = new Dictionary<string, Object>();
    public static Dictionary<GameObject, string> MonobehaviourLookupTable = new Dictionary<GameObject, string>();


    public static void RegisterObject(string ID, Object _object)
    {
        ObjectLookupTable.Add(ID, _object);
    }

    public static void RegisterMonobehaviour(GameObject gameObject, string ID)
    {
        MonobehaviourLookupTable.Add(gameObject, ID);
    }

    public static GameObject GetGameObject(string id)
    {
        return MonobehaviourLookupTable.FirstOrDefault(gameObject => gameObject.Value == id).Key;
    }

    public static string GetObjectID(GameObject gameObject)
    {
        return MonobehaviourLookupTable[gameObject];
    }

    public static Object GetObjectTemp(string ID)
    {
        return ObjectLookupTable[ID];
    }
}
