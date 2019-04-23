using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    void Awake()
    {
        BeginNewLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("RecordGameState", 1f, 1f);
    }

    void BeginNewLevel()
    {   
        // Make sure that the scene containing the enemies
        // is set as the active scene or this will throw an error.
        GameObject enemies = GameObject.Find("Enemies");
        
        if(enemies.transform.childCount > 0)
        {
            // enemyRecorder.Initialize(
            //     enemies.GetComponentsInChildren<Transform>(),
            //     secondsToRewind.value);
        }
    }

    // void RecordGameState()
    // {
    //     if(enemyRecorder.Initialized)
    //         enemyRecorder.SaveEnemyStates();
    // }

    public void OnPlayerDeath()
    {
        BeginNewLevel();
    }

    // IEnumerator Rewind()
    // {
    //     gameHalted = true;
    //     enemyRecorder.DisableColliders(true);
    //     for(int i = 1; i <= secondsToRewind.value; i++)
    //     {
    //         enemyRecorder.Rewind(i);
    //         yield return new WaitForSeconds(0.1f);
    //     }

    //     enemyRecorder.DisableColliders(false);
    //     gameHalted = false;
    // }
}
