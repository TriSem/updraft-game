using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    void OnEnable() => Event.RegisterListener(this);

    void OnDisable() => Event.UnregisterListener(this);

    public void OnEventRaised() => Response.Invoke();

    public void OnEventRaised<T>(T arg0) => (Response as UnityEvent<T>).Invoke(arg0);

    public void OnEventRaised<T0, T1>(T0 arg0, T1 arg1) => 
        (Response as UnityEvent<T0, T1>).Invoke(arg0, arg1);

    public void OnEventRaised<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2) => 
        (Response as UnityEvent<T0, T1, T2>).Invoke(arg0, arg1, arg2);
    
}
