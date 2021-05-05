using UnityEngine;

[System.Serializable]
public class SystemData
{
    //[SerializeField] private KeybindsData _keyBindsData;

    // ???
    [SerializeField] private string _saveFilesPath;
    [SerializeField] private string _saveFileExtension;

    [SerializeField] private string _currentSaveFileName;

    // Game Settings
    //[SerializeField] private SceneID _currentScene;
    //[SerializeField] private GameStateID _currentGameState;



    //public KeybindsData KeybindsData => _keyBindsData;

    public string SaveFilesPath => Application.persistentDataPath + _saveFilesPath;
    public string SaveFileExtension => _saveFileExtension;
    public string CurrentSaveFileName => _currentSaveFileName;
    //public SceneID CurrentScene => _currentScene;
    //public GameStateID CurrentGameState => _currentGameState;

}