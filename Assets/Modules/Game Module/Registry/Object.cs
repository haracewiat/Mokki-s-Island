using UnityEngine;

//[ExecuteInEditMode]
[System.Serializable]
public abstract class Object 
{
    [SerializeField] protected ObjectData objectData;
    [SerializeField] protected TransformData transformData;
    [SerializeField] protected bool isInstantiated;

    public ObjectData ObjectData => objectData;
    public TransformData TransformData => transformData;

    public Object(ObjectData objectData)
    {
        this.objectData = objectData;
    }

    private void OnAction(object paramerer)
    {
        Debug.LogWarning($"[{GetType().Name}] OnAction");

    }

    public void SetData(ObjectData objectData)
    {
        //this.objectData = objectData;

        //transform.position = objectData.TransformData.Position;
        //transform.rotation = objectData.TransformData.Rotation;
    }

    //private void OnEnable()
    //{
    //    Debug.Log("I was just added to the scene!");
    //}

    //private void OnDisable()
    //{
    //    Debug.Log("I was just removed from the scene :(");
    //}

    public virtual void Instantiate()
    {
        // Fetch prefab
        // TODO: First check registry for the prefab
        GameObject gameObjectPrefab = Resources.Load(objectData.PrefabID) as GameObject;

        // Instantiate prefab
        GameObject gameObjectInstance = UnityEngine.Object.Instantiate(gameObjectPrefab);
        isInstantiated = true;

        // Update transofrm of the GameObject
        gameObjectInstance.OverwriteTransform(transformData);

        // Update the registry
        Registry.RegisterMonobehaviour(gameObjectInstance, objectData.ID);
        Registry.RegisterObject(objectData.ID, this);

        // Allow derived class to modify the GameObject
        ModifyGameObject(gameObjectInstance);
    }

    protected abstract void ModifyGameObject(GameObject gameObject);

    // TODO: I want to subscribe to event for my gameobject tranform changed


}



public static class ExtentionMethods
{
    public static void OverwriteTransform(this GameObject gameObject, TransformData transformData)
    {
        Debug.Log($"[{gameObject}] Updating transform to {transformData}");
        gameObject.transform.position = transformData.Position.Vector3;
        gameObject.transform.rotation = transformData.Rotation.Quaternion;
    }
}