using UnityEngine;

[System.Serializable]
public class Seed : Object
{
    public Seed(ObjectData objectData) : base(objectData)
    {
        Debug.Log($"I'm seed! My data is: {objectData}");

    }

    protected override void ModifyGameObject(GameObject gameObject)
    {
        
    }

}
