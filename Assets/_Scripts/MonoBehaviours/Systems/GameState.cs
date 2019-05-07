using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    Scene currentLevel;
    [SerializeField] IntSO playerScore = null;

    void OnEnable()
    {
        BeginPlay();
    }

    public void BeginPlay()
    {
        playerScore.value = 0;
    }
}
