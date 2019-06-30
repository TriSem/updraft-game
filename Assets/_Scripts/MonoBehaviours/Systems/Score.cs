using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] IntSO playerScore = null;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "0";
    }

    public void OnScoreChanged()
    {
        text.text = playerScore.value.ToString();
    }
}
