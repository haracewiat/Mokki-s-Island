using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMonobehaviour : MonoBehaviour
{ 
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public GameObject body;

    //private void Start()
    //{
    //    EventManager.SubscribeTo(EventID.ExecutorChanged, OnExecutorChanged);

    //    OnExecutorChanged(Registry.Data.GameData.CurrentExecutorID);
    //}

    //private void OnExecutorChanged(object parameter)
    //{
    //    // Check if I was selected
    //    if ((string)parameter == objectData.ID)
    //    {
    //        body.GetComponent<Renderer>().material.color = Color.magenta;
    //    }
    //    else
    //    {
    //        body.GetComponent<Renderer>().material.color = Color.white;

    //    }
    //}

}
