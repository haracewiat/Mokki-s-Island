using System.Text;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    [Header("Position")] 
    [SerializeField] private float _positionX;
    [SerializeField] private float _positionY;
    [SerializeField] private float _positionZ;

    [Header("Rotation")]
    [SerializeField] private float _rotationX;
    [SerializeField] private float _rotationY;
    [SerializeField] private float _rotationZ;
    [SerializeField] private float _rotationW;


    public Vector3 Position => new Vector3(_positionX, _positionY, _positionZ);
    public Quaternion Rotation => new Quaternion(_rotationX, _rotationY, _rotationZ, _rotationW);



    // Update Position
    public void Update(Transform transform)
    {
        _positionX = transform.position.x;
        _positionY = transform.position.y;
        _positionZ = transform.position.z;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Position: {Position}");

        return sb.ToString();

    }
}