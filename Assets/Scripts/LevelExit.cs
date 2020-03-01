using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1.35f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    AsyncOperation asyncOperation;

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator SlowMoEffect()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        yield return StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextScene = currentSceneIndex + 1;
        asyncOperation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = true;
        yield return asyncOperation;
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }
}




/*[SerializeField] float LevelLoadDelay = 1.35f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }*/
