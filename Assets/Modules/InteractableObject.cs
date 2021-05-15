using UnityEngine;

public abstract class InteractableObject : Object
{
    [SerializeField] private ActionSet actionSet;

    public ActionSet ActionSet => actionSet;
}
