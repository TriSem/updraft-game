using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    AsyncOperation async = null;
    [SerializeField] StringSO selectedLevelDesignation;
    [SerializeField] BoolSO controlsEnabled;  

    string currentlyLoadedLevel = "";

    void Start()
    {
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

        async = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        yield return async;
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

    public void OnLevelSelected()
    {
        if(selectedLevelDesignation.value == "")
            return;

        controlsEnabled.value = false;
        StartCoroutine(UnloadLevel(currentlyLoadedLevel));
        StartCoroutine(LoadLevel("Level " + selectedLevelDesignation.value ));
        controlsEnabled.value = true;
    }
}
