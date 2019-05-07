using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;

    [SerializeField] int value = 0;

    void OnTriggerEnter()
    {
        playerScore.value += value;
        Destroy(this.gameObject);
    }
}
