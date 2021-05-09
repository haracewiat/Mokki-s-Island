using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMonobehaviour : Entity
{
    [Header("Monobehaviour")]
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public GameObject body;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.ExecutorChanged, OnExecutorChanged);

        OnExecutorChanged(Registry.Data.GameData.CurrentExecutorID);
    }

    private void OnExecutorChanged(object parameter)
    {
        // Check if I was selected
        if ((string)parameter == objectData.ID) {
            body.GetComponent<Renderer>().material.color = Color.magenta;
        }
        else
        {
            body.GetComponent<Renderer>().material.color = Color.white;

        }
    }

}
