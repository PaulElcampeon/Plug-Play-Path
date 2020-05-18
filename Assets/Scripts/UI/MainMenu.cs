using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject soundPanel;

    [SerializeField]
    private GameObject rulesPanel;

    [SerializeField]
    private GameObject creditsPanel;

    public void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    public void OpenRulesPanel()
    {
        rulesPanel.SetActive(true);
    }

    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseActivePanel()
    {
        if (soundPanel.activeInHierarchy) soundPanel.SetActive(false);
        if (rulesPanel.activeInHierarchy) rulesPanel.SetActive(false);
        if (creditsPanel.activeInHierarchy) creditsPanel.SetActive(false);
    }

    public void LoadGame()
    {
        GameManager.instance.LoadScene("Game");
    }
}
