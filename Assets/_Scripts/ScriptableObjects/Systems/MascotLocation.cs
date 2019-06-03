using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascotLocation : ScriptableObject
{
    public Vector3 MascotPosition { get; private set; }

    public void SetMascotPosition(Mascot mascot) => 
        MascotPosition = mascot.transform.position;
}
