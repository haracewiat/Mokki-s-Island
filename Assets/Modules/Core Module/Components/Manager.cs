using UnityEngine;

public class Manager<T> : MonoBehaviour
{
    private static Manager<T> _instance;

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
}