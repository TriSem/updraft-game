// This class was taken from the following Article
// on Unity's website: 
// https://unity3d.com/de/how-to/architect-with-scriptable-objects (last called 10/05/19)

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
