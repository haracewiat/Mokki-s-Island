using UnityEngine;

[System.Serializable]
public class TransformData
{
    [SerializeField] private Vector3Data position;
    [SerializeField] private QuaternionData rotation;

    public Vector3 Position => position.Vector3;
    public Quaternion Rotation => rotation.Quaternion;
}
