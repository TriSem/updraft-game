using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    IEnumerator LoadGame()
    {
        yield return SceneManager.LoadSceneAsync("BaseScene");
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelSelection"));
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); 
        Application.Quit(); 
    }
}
