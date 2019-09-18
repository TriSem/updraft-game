using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torusCollision : MonoBehaviour
{
    public IntSO playerScore = null;
    public GameEvent playerScoreChange = null;
    public BoolSO firstHit = null;
    public GameObject floatingTextPrefab;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstHit.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!firstHit.value)
        {
            if (floatingTextPrefab)
            {
                floatingTextPrefab.SetActive(true);
            }
           
            firstHit.value = true;
            playerScore.value += points;
            playerScoreChange.NotifyListeners();
            //Debug.Log("Torus Hit! Points=" + points);
        }
    }
}
