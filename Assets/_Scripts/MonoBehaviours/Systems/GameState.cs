using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;

    void OnEnable()
    {
        BeginPlay();
    }

    public void BeginPlay()
    {
        playerScore.value = 0;
        playerScoreChange.NotifyListeners();
    }

    public void OnLevelCleared()
    {
        // TODO: Add functionality
    }
}
