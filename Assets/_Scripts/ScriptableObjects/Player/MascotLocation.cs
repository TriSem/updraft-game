using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MascotLocation", menuName="Assets/Player/MascotLocation")]
public class MascotLocation : ScriptableObject
{
    public Vector3 MascotPosition { get; private set; }

    public void SetMascotPosition(Mascot mascot) => 
        MascotPosition = mascot.transform.position;
}
