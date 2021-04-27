using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Manager<EventManager>
{
    private static Dictionary<Enum, Event> _events = new Dictionary<Enum, Event>();

    protected override void Awake()
    {
        base.Awake();
        LoadEvents();
    }

    private static void LoadEvents()
    {
        foreach (EventID id in Enum.GetValues(typeof(EventID)))
            _events.Add(id, new Event(id));
    }

    public static void NotifyAbout<T>(Enum eventId, T parameter)
    {
        _events[eventId].SendNotification(parameter);
    }
    public static void SubscribeTo(Enum eventId, Action<object> subscribingMethod)
    {
        _events[eventId].AddSubscriber(subscribingMethod);
    }

}
