using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Manager<InputManager>
{
    [SerializeField] private Camera _camera;


    // *************** Cursor ***************

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D pointingCursor;


    private void Start()
    {
        ChangeCursor(defaultCursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void ChangeCursor(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    // **************************************

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            EventManager.NotifyAbout(EventID.SaveRequestMade);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            EventManager.NotifyAbout(EventID.LoadRequestMade);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.NotifyAbout(EventID.Space);
        }


        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject()) return; // ignore UI 

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                Registry.UpdateLastClickedObject(hit);
        }

        // TODO: Temporary, move elsewhere
        // Update cursor when hovering over interactable item
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<MonoBehaviour>() is IInteractable)
                {
                    ChangeCursor(pointingCursor);
                    Debug.LogWarning(hit.transform.gameObject.GetComponent<MonoBehaviour>());
                }
                else
                {
                    ChangeCursor(defaultCursor);
                    Debug.Log(hit.transform.gameObject.GetComponent<MonoBehaviour>());
                }
            }
        }
        // ***************************************************

    }



    
}
