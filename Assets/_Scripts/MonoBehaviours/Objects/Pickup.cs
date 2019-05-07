using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] CustomInt playerScore = null;

    [SerializeField] int value = 0;

    void OnTriggerEnter()
    {
        playerScore.value += value;
        Destroy(this.gameObject);
    }
}
