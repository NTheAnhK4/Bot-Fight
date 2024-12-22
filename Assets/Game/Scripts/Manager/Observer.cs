using System;
using System.Collections.Generic;
using UnityEngine;

public static class Observer
{
    private static Dictionary<EventId, Action<object>> observers = new Dictionary<EventId, Action<object>>();

    public static void Attack(EventId id, Action<object> action)
    {
        observers.TryAdd(id, null);
        observers[id] += action;
    }

    public static void Detach(EventId id, Action<object> action)
    {
        if (!observers.ContainsKey(id))
        {
            Debug.LogWarning("Do not contain " + id.ToString() + " in observer");
            return;
        }

        observers[id] -= action;
    }

    public static void Notity(EventId id, object param = null)
    {
        if (!observers.ContainsKey(id))
        {
            Debug.LogWarning("Do not contain " + id.ToString() + " in observer");
            return;
        }

        if (observers[id] != null) observers[id].Invoke(param);
    }
}

public enum EventId
{
    AttackPlayer,
    AttackEnemy
}