using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Patrol))]
public class PatrolPathEditor : Editor
{
    void OnSceneGUI()
    {
        Event guiEvent = Event.current;
        Ray mouse = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
    }
}
