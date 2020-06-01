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

    [SerializeField]
    private GameObject difficultyPanel;

    public void OpenSoundPanel()
    {
        SoundManager.instance.PlaySFX(1);

        soundPanel.SetActive(true);
    }

    public void OpenRulesPanel()
    {
        SoundManager.instance.PlaySFX(1);

        rulesPanel.SetActive(true);
    }

    public void OpenCreditsPanel()
    {
        SoundManager.instance.PlaySFX(1);

        creditsPanel.SetActive(true);
    }

    public void OpenDifficultyPanel()
    {
        SoundManager.instance.PlaySFX(1);

        difficultyPanel.SetActive(true);
    }

    public void CloseActivePanel()
    {
        SoundManager.instance.PlaySFX(2);

        if (soundPanel.activeInHierarchy) soundPanel.SetActive(false);
        if (rulesPanel.activeInHierarchy) rulesPanel.SetActive(false);
        if (creditsPanel.activeInHierarchy) creditsPanel.SetActive(false);
        if (difficultyPanel.activeInHierarchy) difficultyPanel.SetActive(false);

    }

    public void LoadGame()
    {
        GameManager.instance.UnPause();
        GameManager.instance.LoadScene("Game");
    }

    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
