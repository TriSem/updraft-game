using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTimer : MonoBehaviour
{
    [SerializeField] FloatSO remainingTime = null;

    private void Start()
    {
        remainingTime.value = 0;
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
        Debug.Log("Remaining ComboTime: " + remainingTime.value);
    }
}
