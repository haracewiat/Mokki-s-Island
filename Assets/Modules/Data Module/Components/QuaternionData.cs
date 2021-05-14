using UnityEngine;

[System.Serializable]
public class QuaternionData
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float w;

    public Quaternion Quaternion => new Quaternion(x, y, z, w);

    public void Update(Quaternion quaternion)
    {
        x = quaternion.x;
        y = quaternion.y;
        z = quaternion.z;
        w = quaternion.w;
    }
}