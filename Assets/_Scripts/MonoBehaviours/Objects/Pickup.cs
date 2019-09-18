using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;
    [SerializeField] int value = 0;
    [SerializeField] GameObject floatingTextPrefab = null;

    [SerializeField] BoolSO lastPickupBool = null;
    [SerializeField] GameObject Mascot = null;
    [SerializeField] IntSO comboIterator = null;
    int newValue = 0;

    void Update()
    {
        if ((Mascot.transform.position.x - this.transform.position.x) > 2.0)
        {
            lastPickupBool.value = false;
        }
    }


    void OnTriggerEnter()
    {
        if (floatingTextPrefab)
        {
            floatingTextPrefab.SetActive(true);
        }
        lastPickupBool.value = true;
        comboIterator.value++;
        newValue = value * comboIterator.value;

        playerScore.value += newValue;
        playerScoreChange.NotifyListeners();
        Destroy(this.gameObject);
    }

}
