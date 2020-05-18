using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.Pause();
    }

    public void StartGame()
    {
        GameManager.instance.UnPause();
        gameObject.SetActive(false);
    }
}
