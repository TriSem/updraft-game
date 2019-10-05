// This class was taken from the following Article
// on Unity's website: 
// https://unity3d.com/de/how-to/architect-with-scriptable-objects (last called 10/05/19)

using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    void OnEnable() => Event.RegisterListener(this);

    void OnDisable() => Event.UnregisterListener(this);

    public void OnEventRaised() => Response.Invoke();
}
