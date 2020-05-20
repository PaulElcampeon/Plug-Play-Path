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

    private bool isAlreadyOpeningPanel = false;

    public static GameUIManager instance;

    private void Awake()
    {
        instance = this;    
    }

    public void OpenInGameMenu()
    {
        if (nextPanel.activeInHierarchy || retryPanel.activeInHierarchy) return;

        SoundManager.instance.PlaySFX(2);

        GameManager.instance.Pause();

        inGameMenu.SetActive(true);
    }

    public void OpenRetryPanel()
    {
        if (isAlreadyOpeningPanel) return;

        SoundManager.instance.PlaySFX(2);

        isAlreadyOpeningPanel = true;

        StartCoroutine(OpenRetryPanelCoro());
    }

    public void OpenNextPanel()
    {
        if (isAlreadyOpeningPanel) return;

        SoundManager.instance.PlaySFX(4);

        isAlreadyOpeningPanel = true;

        StartCoroutine(OpenNextPanelCoro());
    }

    public void CloseRetryPanel()
    {
        isAlreadyOpeningPanel = false;

        retryPanel.SetActive(false);

        GameManager.instance.UnPause();
    }

    public void CloseNextPanel()
    {
        isAlreadyOpeningPanel = false;

        nextPanel.SetActive(false);

        GameManager.instance.UnPause();
    }

    public IEnumerator OpenRetryPanelCoro()
    {
        yield return new WaitForSeconds(1f);

        GameManager.instance.Pause();

        retryPanel.SetActive(true);
    }

    public IEnumerator OpenNextPanelCoro()
    {
        yield return new WaitForSeconds(1f);

        GameManager.instance.Pause();

        nextPanel.SetActive(true);
    }
}
