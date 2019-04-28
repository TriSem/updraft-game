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
    }

    void BeginNewLevel()
    {   
        // Make sure that the scene containing the enemies
        // is set as the active scene or this will throw an error.
        GameObject enemies = GameObject.Find("Enemies");
        
        if(enemies.transform.childCount > 0)
        {
        }
    }

    public void OnSceneChanged(string sceneName)
    {
        
    }
}
