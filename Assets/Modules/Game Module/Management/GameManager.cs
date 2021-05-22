public class GameManager : Manager<GameManager>
{
    private bool flag = true;
    // private int index = 0;

    protected override void Init()
    {
        EventManager.SubscribeTo(EventID.Space, OnSpace);

        OnSpace();
    }

    private void OnSpace()
    {
        //index += 1;
        //index %= gameObjectLookupTable.Count;

        //Debug.Log($"Object count: {gameObjectLookupTable.Count} \nCurrent index: {index}");
        //data.GameData.SetCurrentExecutorID(data.GameData.ObjectsData[index].ID);
    }


    // TODO: change OnDataLoaded to OnDataChanged (currently using flag)
    protected override void OnDataLoaded()
    {
        base.OnDataLoaded();

        LoadObjects();
    }
    private void LoadObjects()
    {
        if (flag)
        {
            foreach (Object _object in data.GameData.GetObjects())
            {
                _object.Instantiate();
            }

            flag = false;
        }
    }


}
