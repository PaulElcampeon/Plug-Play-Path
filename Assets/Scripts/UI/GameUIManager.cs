using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;

    [SerializeField]
    private GameObject retryPanel;

    [SerializeField]
    private GameObject nextPanel;

    public static GameUIManager instance;

    private void Awake()
    {
        instance = this;    
    }

    public void OpenInGameMenu()
    {
        if (nextPanel.activeInHierarchy || retryPanel.activeInHierarchy) return;

        GameManager.instance.Pause();

        inGameMenu.SetActive(true);
    }

    public void OpenRetryPanel()
    {
        StartCoroutine(OpenRetryPanelCoro());
    }

    public void OpenNextPanel()
    {
        StartCoroutine(OpenNextPanelCoro());
    }

    public void CloseRetryPanel()
    {
        retryPanel.SetActive(false);

        GameManager.instance.UnPause();
    }

    public void CloseNextPanel()
    {
        nextPanel.SetActive(false);

        GameManager.instance.UnPause();
    }

    public IEnumerator OpenRetryPanelCoro()
    {
        yield return new WaitForSeconds(1.5f);

        GameManager.instance.Pause();

        retryPanel.SetActive(true);
    }

    public IEnumerator OpenNextPanelCoro()
    {
        yield return new WaitForSeconds(1.5f);

        GameManager.instance.Pause();

        nextPanel.SetActive(true);
    }
}
