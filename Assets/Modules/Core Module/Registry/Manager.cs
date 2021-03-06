using UnityEngine;

public abstract class Manager<T> : MonoBehaviour
{
    private static Manager<T> _instance;

    [SerializeField] protected SaveData data = null;

    public static Manager<T> Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        EventManager.SubscribeTo(EventID.DataLoaded, OnDataLoaded);
        EventManager.SubscribeTo(EventID.DataChanged, OnDataChanged);

        EventManager.NotifyAbout(EventID.DataRequested);

        Init();
    }

    protected virtual void Init() { }

    //protected virtual void OnDataLoaded(object parameter)
    //{
    //    if (data != null) { data = (SaveData)parameter; }
    //}

    //protected virtual void OnDataChanged(object parameter)
    //{
    //    data = (SaveData)parameter;
    //}

    // TODO: No need to keep data: it is now in the registry
    protected virtual void OnDataLoaded()
    {
        // TODO: Needed? It always holds reference...
        if (data != null) { data = (SaveData)Registry.Data; }
    }

    protected virtual void OnDataChanged()
    {
        data = (SaveData)Registry.Data;
    }
}