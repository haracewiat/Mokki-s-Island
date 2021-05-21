using System.Text;
using UnityEngine;

[System.Serializable]
public class TransformData : Data
{
    [SerializeField] private Vector3Data position;
    [SerializeField] private QuaternionData rotation;

    public Vector3Data Position => position;
    public QuaternionData Rotation => rotation;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Position: {position}");
        sb.AppendLine($"Rotation: {rotation}");

        return sb.ToString();
    }
}
