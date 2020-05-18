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
        GameManager.instance.Pause();

        soundPanel.SetActive(true);
    }

    public void Close()
    {
        GameManager.instance.LoadScene("Menu");
    }
}
