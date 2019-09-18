using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] static float comboResetTime = 2f;

    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;
    [SerializeField] GameObject floatingTextPrefab = null;
    [SerializeField] FloatSO remainingComboTime = null;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] int value = 0;


    void OnTriggerEnter()
    {

        if (floatingTextPrefab)
        {
            var instance = Instantiate(floatingTextPrefab, transform.position + new Vector3(0f,2f,0f), floatingTextPrefab.transform.rotation);
            instance.GetComponent<FloatingText>().Points = value;
        }
        int bonus = value;

        if (remainingComboTime.value > 0)
        {
            comboIterator.value++;
            bonus = value * comboIterator.value;
        }

        playerScore.value += bonus;
        remainingComboTime.value = comboResetTime;
        playerScoreChange.NotifyListeners();
        Destroy(this.gameObject);
    }

}
