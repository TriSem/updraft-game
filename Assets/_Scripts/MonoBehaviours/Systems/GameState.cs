using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    Scene currentLevel;

    BoolSO controlsEnabled = null;
    IntSO playerScore = null;

    List<Enemy> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        var enemiesObject = GameObject.Find("Enemies");
        if(enemiesObject.transform.childCount > 0)
        {
            enemies.AddRange(
                enemiesObject.transform.GetComponentsInChildren<Enemy>()
            );
        }
    }

    public void BeginPlay()
    {
        playerScore.value = 0;
    }
}
