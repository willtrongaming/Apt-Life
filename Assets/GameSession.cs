using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    int playerLives = 10;
    [SerializeField] Text livesText;
    AsyncOperation asyncOperation;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        StartCoroutine(ReloadCurrentLevel());
        
        livesText.text = playerLives.ToString();
    }

    private IEnumerator ReloadCurrentLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var currentSceneReloaded = currentSceneIndex;
        asyncOperation = SceneManager.LoadSceneAsync(currentSceneReloaded, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = true;
        yield return asyncOperation;
        SceneManager.UnloadSceneAsync(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void DestroyOnReplayButton()
    {
        Destroy(gameObject);
    }
}


/*private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }*/
