using System.Text;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private MotionData _motionData;
    [SerializeField] private TransformData _transformData;
    [SerializeField] private ActionsData actionsData;

    public MotionData MotionData => _motionData;
    public TransformData TransformData => _transformData;
    public ActionsData ActionsData => actionsData;


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{GetType().Name}:");
        sb.AppendLine(_motionData.ToString());
        sb.AppendLine(_transformData.ToString());
        sb.AppendLine(actionsData.ToString());

        return sb.ToString();
    }
}