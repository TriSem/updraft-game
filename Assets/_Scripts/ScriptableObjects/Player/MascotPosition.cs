using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MascotPosition", menuName="Assets/Player/MascotPosition")]
public class MascotPosition : ScriptableObject
{
    public Vector3 Position { get; private set; }

    public void SetMascotPosition(Mascot mascot) => 
        Position = mascot.transform.position;
}
