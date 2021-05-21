using System.Text;
using UnityEngine;

[System.Serializable]
public class QuaternionData : Data
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

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Quaternion: {Quaternion} (Vector3: {Quaternion.eulerAngles})");
        
        return sb.ToString();
    }
}