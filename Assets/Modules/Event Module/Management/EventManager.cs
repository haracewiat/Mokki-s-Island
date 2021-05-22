using System;
using System.Collections.Generic;

public class EventManager : Manager<EventManager>
{
    private static Dictionary<Enum, Event> events = new Dictionary<Enum, Event>();

    protected override void Awake()
    {
        base.Awake();
        LoadEvents();
    }

    private static void LoadEvents()
    {
        foreach (EventID id in Enum.GetValues(typeof(EventID)))
            events.Add(id, new Event(id));
    }

    public static void NotifyAbout(Enum eventId)
    {
        events[eventId].SendNotification();
    }
    public static void SubscribeTo(Enum eventId, System.Action subscribingMethod)
    {
        events[eventId].AddSubscriber(subscribingMethod);
    }

}
