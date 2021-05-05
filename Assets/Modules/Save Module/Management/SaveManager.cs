using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : Manager<SaveManager>
{
    [SerializeField] private string _saveFilesPath;
    [SerializeField] private string _saveFileExtension;

    private BinaryFormatter binaryFormatter;

    protected override void Awake()
    {
        base.Awake();
        binaryFormatter = new BinaryFormatter();
    }

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.DataLoaded, OnGameDataLoaded);
        EventManager.SubscribeTo(EventID.LoadRequestMade, OnLoadRequestMade);
        EventManager.SubscribeTo(EventID.DataSaved, OnGameDataSaved);

        EventManager.NotifyAbout(EventID.DataRequested, "");
    }

    private void OnGameDataLoaded(object parameter)
    {
        _saveFileExtension = ((Data)parameter).SystemData.SaveFileExtension;
        _saveFilesPath = ((Data)parameter).SystemData.SaveFilesPath;
    }

    private void OnLoadRequestMade(object parameter)
    {
        // Load the indicated file 
        // Data loadedData = (Data)Load((string)parameter);
        Data loadedData = (Data)Load("/file1");

        EventManager.NotifyAbout(EventID.SaveFileLoaded, loadedData);
    }


    private void OnGameDataSaved(object parameter)
    {
        string fileName = ((Save)parameter).FileName;
        object objectToSave = ((Save)parameter).ObjectToSave;

        fileName = fileName == string.Empty ? SetDefaultFileName() : fileName;

        Save(fileName, objectToSave);
    }

    private string SetDefaultFileName()
    {
        int numberOfSaves = GetNumberOfSaves();
        return "save_" + (numberOfSaves.ToString()).PadLeft(3, '0');
    }

    private int GetNumberOfSaves()
    {
        var files = Directory.GetFiles(_saveFilesPath);
        return files.Length;
    }

    private void Save(string fileName, object objectToSave)
    {
        Directory.CreateDirectory(_saveFilesPath);

        using FileStream fileStream = new FileStream(_saveFilesPath + fileName + _saveFileExtension, FileMode.Create);
        binaryFormatter.Serialize(fileStream, objectToSave);

        EventManager.NotifyAbout(EventID.SaveFileSaved, "");
    }

    private object Load(string fileName)
    {
        object loadedObject = default;

        string filePath = _saveFilesPath + fileName + _saveFileExtension;
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            loadedObject = binaryFormatter.Deserialize(fileStream);
        }

        return loadedObject;
    }

    private void Delete(string fileName)
    {
        string filePath = _saveFilesPath + fileName + _saveFileExtension;
        File.Delete(filePath);
    }

    private bool SaveExists(string fileName)
    {
        string filePath = _saveFilesPath + fileName + _saveFileExtension;
        return File.Exists(filePath);
    }
}