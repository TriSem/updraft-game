using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    AsyncOperation async = null;
    StringSO selectedLevelDesignation;

    void Start()
    {
        StartCoroutine(LoadLevelSelect());
    }

    IEnumerator LoadLevelSelect()
    {
        yield return LoadLevel("LevelSelect");
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

    void OnLevelSelected(string levelName)
    {
        
    }
}
