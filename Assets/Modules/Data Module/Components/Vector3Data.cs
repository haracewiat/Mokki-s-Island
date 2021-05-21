using System.Text;
using UnityEngine;

[System.Serializable]
public class Vector3Data : Data
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    public Vector3 Vector3 => new Vector3(x, y, z);

    public Vector3Data(Vector3 vector3) {
        Update(vector3);
    }

    public void Update(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Vector3: {Vector3}");

        return sb.ToString();
    }
}
