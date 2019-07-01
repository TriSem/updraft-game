using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEmitter : MonoBehaviour
{
    [SerializeField] int particleNumber = 1;
    
    [SerializeField] ParticleSystem emitter;


    public void Emit()
    {
        emitter.Emit(particleNumber);
    }
}
