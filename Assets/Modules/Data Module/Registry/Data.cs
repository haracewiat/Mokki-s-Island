[System.Serializable]
public abstract class Data
{
    // Who subscribes property

    public void SubscribeToChange()
    {

    }

    //public void Unsubscribe(); 

    private void NotifyAboutChange()
    {

    }

    
    public abstract override string ToString();
}
