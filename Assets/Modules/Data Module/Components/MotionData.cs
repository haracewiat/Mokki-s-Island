using System.Text;
using UnityEngine;

[System.Serializable]
public class MotionData
{
    [Header("Motion attributes")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    public float WalkSpeed { get { return walkSpeed; } }
    public float RunSpeed { get { return runSpeed; } }
    public float JumpForce { get { return jumpForce; } }


   
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Walk speed: " + walkSpeed);
        sb.AppendLine("Run speed: " + runSpeed);
        sb.AppendLine("Jump force: " + jumpForce);

        return sb.ToString();

    }
}