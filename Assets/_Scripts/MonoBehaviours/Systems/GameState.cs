using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] IntSO playerScore = null;
    [SerializeField] GameEvent playerScoreChange = null;
    [SerializeField] GameObject scoreText = null;
    [SerializeField] GameObject comboSlider = null;

    void OnEnable()
    {
        BeginPlay();
    }

    public void BeginPlay()
    {
        scoreText.SetActive(true);
        comboSlider.SetActive(true);
        playerScore.value = 0;
        playerScoreChange.NotifyListeners();
    }

    public void OnLevelCleared()
    {
        scoreText.SetActive(false);
        comboSlider.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        scoreText.SetActive(false);
        comboSlider.SetActive(false);
    }
}
