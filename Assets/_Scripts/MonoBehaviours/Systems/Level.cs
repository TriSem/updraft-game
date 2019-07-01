using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] GameState gameState = null;
    [SerializeField] GameObject loadScreen = null;
    [SerializeField] StringSO selectedLevelDesignation = null;
    [SerializeField] BoolSO controlsEnabled = null;  

    string currentlyLoadedLevel = "";

    void Start()
    {
        if(SceneManager.sceneCount > 1 && Application.isEditor)
        {
            currentlyLoadedLevel = SceneManager.GetActiveScene().name;
            return;
        }
        
        StartCoroutine(LoadLevelSelect());
        currentlyLoadedLevel = "LevelSelection";
    }

    IEnumerator LoadLevelSelect()
    {
        yield return LoadLevel("LevelSelection");
    }

    IEnumerator LoadLevel(string levelName)
    {
        if(Application.isEditor)
        {
            int sceneCount = SceneManager.sceneCount;
            for(int i = sceneCount - 1; i >= 0; i--)
            {
                if(SceneManager.GetSceneAt(i).name == levelName)
                    yield break;
            }
        }

        var async = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        yield return async;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
    }

    IEnumerator UnloadLevel(string levelName)
    {
        int sceneCount = SceneManager.sceneCount;
        bool cancel = true;
        for(int i = sceneCount - 1; i >= 0; i--)
        {
            if(SceneManager.GetSceneAt(i).name == levelName)
                cancel = false;
        }

        if(cancel)
            yield break;

        yield return SceneManager.UnloadSceneAsync(levelName);
    }

    void Load(string levelName)
    {
        loadScreen.SetActive(true);
        gameState.gameObject.SetActive(false);
        controlsEnabled.value = false;
        StartCoroutine(UnloadLevel(currentlyLoadedLevel));
        StartCoroutine(LoadLevel(levelName));
        currentlyLoadedLevel = levelName;
        loadScreen.SetActive(false);
        controlsEnabled.value = true;
        gameState.gameObject.SetActive(true);
    }

    public void OnLevelSelected()
    {
        if(selectedLevelDesignation.value == "")
            return;

        Load("Level " + selectedLevelDesignation.value);
    }

    public void OnPlayerDeath()
    {
        Load("LevelSelection");
    }

    public void OnLevelCleared()
    {
        // TODO: Add Scoreboard etc.
        Load("LevelSelection");
    }
}
