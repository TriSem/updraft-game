using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] TMP_Text comboText = null;
    [SerializeField] FloatSO remainingTime = null;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] Image fill = null;
    [SerializeField] FloatSO comboResetTime = null;
    [SerializeField] Color comboStartColor;
    int currentComboCount = 1;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = comboResetTime.value;
    }

    void Update()
    {
        if(currentComboCount != comboIterator.value)
        {
            currentComboCount = comboIterator.value;
            brightenFillColor();
        }
        else if(currentComboCount == 1)
        {
            fill.color = comboStartColor;
        }
        slider.value = remainingTime.value;
        comboText.text = "Combo: x" + comboIterator.value;
    }

    void brightenFillColor()
    {
        Color currentColor = fill.color;
        float newRed = currentColor.r * 1.5f;
        float newGreen = currentColor.g * 1.5f;
        float newBlue = currentColor.b * 1.5f;
        fill.color = new Color(newRed, newGreen, newBlue, 0.2f);
    }
}
