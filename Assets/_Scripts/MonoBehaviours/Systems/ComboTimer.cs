using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTimer : MonoBehaviour
{
    [SerializeField] FloatSO remainingTime = null;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] BoolSO firstPickup = null;
    [SerializeField] FloatSO comboResetTimeSO = null;
    [SerializeField] float comboResetTime = 0;

    private void Start()
    {
        remainingTime.value = 0;
        comboIterator.value = 1;
        firstPickup.value = true;
        comboResetTimeSO.value = comboResetTime;
    }
    void StartTimer(float duration)
    {
        remainingTime.value = duration;
    }

    void Update()
    {
        if (remainingTime.value > 0)
        {
            remainingTime.value -= Time.deltaTime;
            remainingTime.value = Mathf.Max(remainingTime.value, 0);
        }
        else
        {
            comboIterator.value = 1;
        }
    }
}
