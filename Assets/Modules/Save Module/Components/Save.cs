public class Save
{
    private string _fileName;
    private object _objectToSave;

    public string FileName => _fileName;
    public object ObjectToSave => _objectToSave;

    public Save(string fileName, object objectToSave)
    {
        _fileName = fileName;
        _objectToSave = objectToSave;
    }

}