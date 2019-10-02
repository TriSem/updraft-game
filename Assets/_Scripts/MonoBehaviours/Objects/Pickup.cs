using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] static float comboResetTime = 0f;

    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;
    [SerializeField] GameObject floatingTextPrefab = null;
    [SerializeField] FloatSO remainingComboTime = null;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] int value = 0;
    [SerializeField] Color color = new Color();
    [SerializeField] BoolSO firstPickup = null;
    [SerializeField] FloatSO comboResetTimeSo = null;


    private void Start()
    {
        comboResetTime = comboResetTimeSo.value;
    }
    void OnTriggerEnter()
    {
        int bonus = value;
        if(firstPickup.value)
        {
            bonus = value;
            comboIterator.value++;
            firstPickup.value = false;
        }
        else if(remainingComboTime.value > 0)
        {
            bonus = value * comboIterator.value;
            comboIterator.value++;
        }
        else
        {
            comboIterator.value = 1;
            firstPickup.value = true;
        }
        playerScore.value += bonus;
        remainingComboTime.value = comboResetTime;

        if (floatingTextPrefab)
        {
            var instance = Instantiate(floatingTextPrefab, transform.position + new Vector3(0f,2f,0f), floatingTextPrefab.transform.rotation);
            instance.GetComponent<FloatingText>().Points = bonus;
            instance.GetComponent<FloatingText>().Color = color;
        }
        

        playerScoreChange.NotifyListeners();
        Destroy(this.gameObject);
    }

}
