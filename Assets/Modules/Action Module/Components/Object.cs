using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    [SerializeField] private ObjectData objectData;

    public ObjectData ObjectData => objectData;

    public void SetData(ObjectData objectData)
    {
        this.objectData = objectData;
    }

}
