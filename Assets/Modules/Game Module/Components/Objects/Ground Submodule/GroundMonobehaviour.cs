using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonobehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private ActionSet actionSet;
    public ActionSet ActionSet => actionSet;
}
