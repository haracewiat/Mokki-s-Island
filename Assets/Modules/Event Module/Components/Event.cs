using System;

public class Event
{
    private Enum eventID;
    private event System.Action action;

    public Event(Enum eventID) { this.eventID = eventID; }

    public void AddSubscriber(System.Action subscribingMethod) { action += subscribingMethod; }

    public void RemoveSubscriber(System.Action subscribingMethod) { action -= subscribingMethod; }

    public void SendNotification() { action?.Invoke(); }
}
