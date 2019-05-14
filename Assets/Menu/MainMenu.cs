using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    IEnumerator LoadGame()
    {
        yield return SceneManager.LoadSceneAsync("BaseScene");
        yield return SceneManager.LoadSceneAsync("LevelSelection", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelSelection"));
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
