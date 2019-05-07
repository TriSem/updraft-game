using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    AsyncOperation async = null;

    void Start()
    {
        StartCoroutine(LoadLevelSelect());
    }

    void Update()
    {
        
    }

    IEnumerator LoadLevelSelect()
    {
        if(Application.isEditor)
        {
            int sceneCount = SceneManager.sceneCount;
            for(int i = sceneCount - 1; i >= 0; i--)
            {
                if(SceneManager.GetSceneAt(i).name == "LevelSelection")
                yield break;
            }
        }

        async = SceneManager.LoadSceneAsync("LevelSelection", LoadSceneMode.Additive);
        yield return async;
    }

    void OnLevelSelected(string levelName)
    {
        
    }
}
