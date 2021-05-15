using UnityEngine;

[ExecuteInEditMode]
public abstract class Object : MonoBehaviour
{
    [SerializeField] protected ObjectData objectData;

    public ObjectData ObjectData => objectData;

    public void SetData(ObjectData objectData)
    {
        this.objectData = objectData;

        transform.position = objectData.TransformData.Position;
        transform.rotation = objectData.TransformData.Rotation;

        Init();
    }

    //private void OnEnable()
    //{
    //    Debug.Log("I was just added to the scene!");
    //}

    //private void OnDisable()
    //{
    //    Debug.Log("I was just removed from the scene :(");
    //}

    protected abstract void Init();

}


[ExecuteInEditMode]
public static class ExtentionMethods
{
    

    //public static void CheckIfObjectComponentPresent(this GameObject gameObject)
    //{
    //    Object _object;
    //    if (!gameObject.TryGetComponent(out _object))
    //    {
    //        Debug.LogWarning("No Object component");
    //    } else
    //    {
    //        Debug.Log("OK");
    //    }
    //}

    //static void HierarchyMonitor()
    //{
    //    EditorApplication.hierarchyChanged += OnHierarchyChanged;
    //}

    //static void OnHierarchyChanged()
    //{
    //    var all = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        
    //    foreach (var a in all)
    //    {
    //        ((GameObject)a).CheckIfObjectComponentPresent();
    //    }
    //}
}