using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene to load")]
    public string targetScene;

    public GameObject loadingScreen;

    public void LoadScene()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);

        while (!op.isDone)
            yield return null;
    }
}