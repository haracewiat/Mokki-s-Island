using UnityEngine;

public class SeedMonobehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private ActionSet actionSet;
    private string ID;
    public ActionSet ActionSet => actionSet;

    private void Start()
    {
        ID = Registry.GetObjectID(gameObject);
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            Registry.GetObjectTemp(ID).TransformData.Position.Update(transform.position);
            Registry.GetObjectTemp(ID).TransformData.Rotation.Update(transform.rotation);

            transform.hasChanged = false;
        }
    }
}
