using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject soundPanel;

    public void CloseActivePanel()
    {
        SoundManager.instance.PlaySFX(2);

        GameManager.instance.UnPause();

        if (soundPanel.activeInHierarchy)
        {
            soundPanel.SetActive(false);
            return;
        }

        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            return;
        }
    }

    public void OpenSoundPanel()
    {
        SoundManager.instance.PlaySFX(1);

        GameManager.instance.Pause();

        soundPanel.SetActive(true);
    }

    public void Close()
    {
        SoundManager.instance.StopCurrentBGM();

        GameManager.instance.LoadScene("Menu");
    }
}
