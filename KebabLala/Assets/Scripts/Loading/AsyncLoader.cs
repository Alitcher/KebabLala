using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] protected GameObject OriginalScene;
    [SerializeField] protected GameObject LoadingScene;
    [SerializeField] protected GameObject TargetScene;

    [SerializeField] private Slider loadingBar;

    private bool isLoading = false;
    private float pregressValue;

    const float completionThreshold = 0.9f;
    public void LoadNextScene(string sceneName)
    {

        isLoading = true;
        SetActiveLoading();
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private void SetActiveLoading()
    {
        OriginalScene.SetActive(false);
        LoadingScene.SetActive(true);

    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation loapOp = SceneManager.LoadSceneAsync(sceneName);
        while (!loapOp.isDone) {
            pregressValue = Mathf.Clamp01(loapOp.progress / completionThreshold);
            loadingBar.value = pregressValue;
            yield return null;
        }
    }
}
