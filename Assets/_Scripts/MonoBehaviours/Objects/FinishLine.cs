using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameEvent levelClear = null;

    void OnTriggerEnter()
    {
        levelClear.NotifyListeners();
    }
}
