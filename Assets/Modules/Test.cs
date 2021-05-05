using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test : MonoBehaviour
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

    protected virtual void Init() { }

}
