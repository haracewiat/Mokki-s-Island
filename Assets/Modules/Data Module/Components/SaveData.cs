using System.Text;
using UnityEngine;

[System.Serializable]
public class SaveData : Data
{
    [SerializeField] PlayerData playerData;
    //[SerializeField] WorldData _worldData;
    [SerializeField] SystemData systemData;
    [SerializeField] GameData gameData;



    public PlayerData PlayerData => playerData;
    //public WorldData WorldData => _worldData;
    public SystemData SystemData => systemData;
    public GameData GameData => gameData;


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(playerData.ToString());
        //sb.AppendLine(WorldData.ToString());
        sb.AppendLine(systemData.ToString());
        sb.AppendLine(gameData.ToString());


        return sb.ToString();
    }
}