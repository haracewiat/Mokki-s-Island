using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : Entity
{
    public Player(ObjectData objectData) : base(objectData)
    {
        Debug.Log($"I'm player! My data is: {objectData}");
    }

    protected override void ModifyGameObject(GameObject gameObject)
    {
        
    }
}
