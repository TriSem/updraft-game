using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    Scene currentLevel;

    CustomBool controlsEnabled = null;

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

        if(Application.isEditor && AnyLevelIsLoaded())
        {
            return;
        }

        StartCoroutine(LoadLevel("Level 1"));
    }

    IEnumerator LoadLevel(string sceneName)
    {   
        controlsEnabled.value = false;
        yield return SceneManager.UnloadSceneAsync(currentLevel.name);
        currentLevel = SceneManager.GetSceneByName(sceneName);
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(currentLevel);
    }

    public void OnSceneChanged(string sceneName)
    {
        if(currentLevel.name == sceneName)
            return;
        StartCoroutine(LoadLevel(sceneName));

        // Make sure that the scene containing the enemies
        // is set as the active scene or this will throw an error.
        GameObject enemies = GameObject.Find("Enemies");
        
        if(enemies.transform.childCount > 0)
        {
        }

        controlsEnabled.value = true;
    }

    /** Returns true, if any level is loaded. */
    bool AnyLevelIsLoaded()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++) 
        {
            Scene loadedScene = SceneManager.GetSceneAt(i);
            if (loadedScene.name.Contains("Level ")) {
                SceneManager.SetActiveScene(loadedScene);
                return true;
            }
        }
        return false;
    }
}
