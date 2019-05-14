using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;

    [SerializeField] int value = 0;

    void OnTriggerEnter()
    {
        playerScore.value += value;
        playerScoreChange.NotifyListeners(playerScore.value);
        Destroy(this.gameObject);
    }
}
