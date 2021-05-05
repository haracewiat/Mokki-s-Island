using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : Manager<DataManager>
{
    [Header("Current data")]
    [SerializeField] private Data _data;

    [Header("Cached default data")]
    private Data _defaultData;

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

        EventManager.NotifyAbout(EventID.DataLoaded, _data);
    }
    

    private void OnNewGameRequested(object parameter)
    {
        _data = _defaultData;
        EventManager.NotifyAbout(EventID.DataChanged, _data);
    }

    private void OnSaveFileLoaded(object parameter)
    {
        _data = (Data)parameter;
        EventManager.NotifyAbout(EventID.DataChanged, _data);
    }

    private void OnGameDataRequested(object parameter)
    {
        EventManager.NotifyAbout(EventID.DataLoaded, _data);
    }

    private void OnSaveRequestMade(object parameter)
    {
        // string fileName = (string)parameter;
        EventManager.NotifyAbout(EventID.DataSaved, new Save("/file1", _data));
    }

    private void OnQuicksave(object parameter)
    {
        string fileName = _data.SystemData.CurrentSaveFileName;
        EventManager.NotifyAbout(EventID.DataSaved, new Save(fileName, _data));
    }
}