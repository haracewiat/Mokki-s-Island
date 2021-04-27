using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Manager<InputManager>
{
    [SerializeField] private Camera _camera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // EventManager.NotifyAbout(EventID.DestinationSet, hit.point);
                EventManager.NotifyAbout(EventID.CommandDispatched, hit);

            }
        }
    }
}
