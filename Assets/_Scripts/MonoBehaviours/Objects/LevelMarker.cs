using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMarker : MonoBehaviour
{
    [SerializeField] StringSO selectedLevelDesignation = null; 

    [SerializeField] string designation = "";

    void OnTriggerEnter()
    {
        selectedLevelDesignation.value = designation;
    }

    void OnTriggerExit()
    {
        selectedLevelDesignation.value = "";
    }
}
