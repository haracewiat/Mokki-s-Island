using UnityEngine;

// TODO: Make abstract 
public class InteractableObject : Object
{
    [SerializeField] private ActionSet actionSet;

    public ActionSet ActionSet => actionSet;
}
