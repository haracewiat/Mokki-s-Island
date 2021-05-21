using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTIleTEST : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private ActionID actionID;


    public void SetActionID(ActionID actionID)
    {
        this.actionID = actionID;
        text.text = actionID.ToString();
    }


    public void OnClick()
    {
        Registry.UpdateLastChosenAction(actionID);
        EventManager.NotifyAbout(EventID.CommandIssued, "");

        // Clean the panel
        for (int i = 1; i < transform.parent.transform.childCount; i++)
            Destroy(transform.parent.transform.GetChild(i).gameObject);
    }
}
