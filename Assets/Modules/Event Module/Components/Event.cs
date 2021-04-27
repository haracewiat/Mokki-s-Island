using System;

public class Event
{
    private Enum _eventID;
    private event Action<object> _action;

    public Event(Enum eventID) { _eventID = eventID; }

    public void AddSubscriber(Action<object> subscribingMethod) { _action += subscribingMethod; }

    public void RemoveSubscriber(Action<object> subscribingMethod) { _action -= subscribingMethod; }

    public void SendNotification(object parameter) { _action?.Invoke(parameter); }
}
