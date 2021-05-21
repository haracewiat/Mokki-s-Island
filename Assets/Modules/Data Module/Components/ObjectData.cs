using UnityEngine;

[System.Serializable]
public class ObjectData
{
    [SerializeField] private string name;
    [SerializeField] private string id;
    [SerializeField] private string prefabID;
    

    public string ID => id;
    public string PrefabID => prefabID;
    
    public void SetID(string id)
    {
        this.id = id;
    }

    public override string ToString()
    {

        return $"{name}, {id}, {prefabID}";
    }

}