using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ground : Object
{
    public Ground(ObjectData objectData) : base(objectData)
    {
        Debug.Log($"I'm ground! My data is: {objectData}");

    }

    protected override void ModifyGameObject(GameObject gameObject)
    {
        
    }
}
