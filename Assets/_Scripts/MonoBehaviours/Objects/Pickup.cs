using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;
    [SerializeField] int value = 0;
    //[SerializeField] GameEvent showFloatingText = null;
    //[SerializeField] string myColor = "";
    //[SerializeField] StringSO currentPickupColor = null;
    //[SerializeField] IntSO currentPoints = null;
    public GameObject floatingTextPrefab;

    void OnTriggerEnter()
    {
        if(floatingTextPrefab)
        {
            showFloatingText();
        }
        //currentPoints.value = value;
        //currentPickupColor.value = myColor;
        //showFloatingText.NotifyListeners();

        playerScore.value += value;
        playerScoreChange.NotifyListeners();

        Destroy(this.gameObject);
    }

     void showFloatingText()
    {
        floatingTextPrefab.SetActive(true);
    }
}
