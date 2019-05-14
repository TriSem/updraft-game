using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
    }

    public void OnScoreChanged(int score)
    {
        text.text = score.ToString();
    }
}
