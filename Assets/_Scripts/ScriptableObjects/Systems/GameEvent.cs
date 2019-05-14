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


    public void RegisterListener(GameEventListener listener) 
        => listeners.Add(listener);
    
    public void UnregisterListener(GameEventListener listener)
        => listeners.Remove(listener);

    public void RemoveAllListeners()
    {
        listeners.Clear();
    }
}
