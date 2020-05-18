using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startGameUI;

    [SerializeField]
    private GameObject inGameMenu;

    [SerializeField]
    private GameObject retryPanel;

    [SerializeField]
    private GameObject nextPanel;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void OpenInGameMenu()
    {
        Pause();
        inGameMenu.SetActive(true);
    }

    public void OpenRetryPanel()
    {
        retryPanel.SetActive(true);
    }

    public void OpenNextPanel()
    {
        nextPanel.SetActive(true);
    }

    public void Retry()//we do not add to the difficulty level as the player is retrying
    {
        GameGenerator.instance.Generate();

        retryPanel.SetActive(false);
        startGameUI.SetActive(true);
    }

    public void Next()
    {
        //We need to generate the new map then we need to close the next panel and then bring up the StartGame Button
        GameGenerator.instance.difficulty += 1;
        GameGenerator.instance.Generate();

        nextPanel.SetActive(false);
        startGameUI.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quiting Game...");

        Application.Quit();
    }
}
