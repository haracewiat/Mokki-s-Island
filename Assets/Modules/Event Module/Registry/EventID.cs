public enum EventID 
{
    // Game Management
    DataLoaded,
    DataSaved,
    DataChanged,
    DataRequested,
    NewGameRequested,
    LoadRequestMade,
    SaveRequestMade,
    SaveFileLoaded,
    SaveFileSaved,



    CommandDispatched, // Issued
    CommandCanceled,
    Move,

    DestinationSet,
}
