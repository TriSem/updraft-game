using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Assets/Systems/GameEvent")]
/** GameEvent without the option to pass data. */
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = 
        new List<GameEventListener>();

    public void NotifyListeners()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void NotifyListeners<T>(T arg0)
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(arg0);
        }
    }

    public void NotifyListeners<T0, T1>(T0 arg0, T1 arg1)
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(arg0, arg1);
        }
    }

    public void NotifyListeners<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(arg0, arg1, arg2);
        }
    }

    public void RegisterListener(GameEventListener listener) 
        => listeners.Add(listener);
    
    public void UnregisterListener(GameEventListener listener)
        => listeners.Remove(listener);

    public void RemoveAllListeners()
    {
        listeners.Clear();
    }
}
