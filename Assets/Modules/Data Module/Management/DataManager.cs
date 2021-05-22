using UnityEngine;

public class DataManager : Manager<DataManager>
{
    [Header("Default data")]
    [SerializeField] private SaveData _data;

    [Header("Cached default data")]
    private SaveData _defaultData;

    protected override void Awake()
    {
        base.Awake();
        _defaultData = _data;
    }

    protected override void Init() {
        EventManager.SubscribeTo(EventID.NewGameRequested, OnNewGameRequested);
        EventManager.SubscribeTo(EventID.SaveFileLoaded, OnSaveFileLoaded);
        EventManager.SubscribeTo(EventID.DataRequested, OnGameDataRequested);
        EventManager.SubscribeTo(EventID.SaveRequestMade, OnSaveRequestMade);
        // EventManager.SubscribeTo(ActionID.Quicksave, OnQuicksave);

        EventManager.NotifyAbout(EventID.DataLoaded);
        Registry.UpdateData(_data);
    }
    

    private void OnNewGameRequested()
    {
        _data = _defaultData;
        EventManager.NotifyAbout(EventID.DataChanged);
    }

    private void OnSaveFileLoaded()
    {
        Registry.UpdateData(_data);
        EventManager.NotifyAbout(EventID.DataChanged);
    }

    private void OnGameDataRequested()
    {
        EventManager.NotifyAbout(EventID.DataLoaded);
    }

    private void OnSaveRequestMade()
    {
        // string fileName = (string)parameter;
        // EventManager.NotifyAbout(EventID.DataSaved, new Save("/file1", _data));
        // TODO: Create save file in registry (only save name really, which should be in data itself)
        EventManager.NotifyAbout(EventID.DataSaved);

    }

    private void OnQuicksave()
    {
        string fileName = _data.SystemData.CurrentSaveFileName;
        // EventManager.NotifyAbout(EventID.DataSaved, new Save(fileName, _data));
        EventManager.NotifyAbout(EventID.DataSaved);

    }
}