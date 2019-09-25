using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboBar : MonoBehaviour
{
    // Unity UI References
    Slider slider;
    [SerializeField] TMP_Text comboText;
    [SerializeField] FloatSO remainingTime = null;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] Image fill;
    int currentComboCount = 1;

    private void Start()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentComboCount != comboIterator.value)
        {
            currentComboCount = comboIterator.value;
            changeFillColor();
        }
        else if(currentComboCount == 1)
        {
            fill.color = new Color(0.1f, 0.05f, 0.05f);
        }
        
        slider.value = remainingTime.value;
        comboText.text = "X" + comboIterator.value;
        
    }

    void changeFillColor()
    {
        Color currentColor = fill.color;
        float newRed = currentColor.r * 1.5f;
        float newGreen = currentColor.g * 1.5f;
        float newBlue = currentColor.b * 1.5f;
        fill.color = new Color(newRed, newGreen, newBlue);
    }
}
