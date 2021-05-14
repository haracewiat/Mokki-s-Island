using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action Set", menuName = "Data/Action Set")]
public class ActionSet : ScriptableObject
{
    [SerializeField] private List<ActionID> actions;

    public List<ActionID> Actions => actions;
}